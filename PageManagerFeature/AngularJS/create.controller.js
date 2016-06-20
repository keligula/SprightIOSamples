
(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('createPageController', CreatePageController);

    CreatePageController.$inject = ['$scope', '$baseController', "$cmsService", "$routeParams", "$location"];

    function CreatePageController(
        $scope
        , $baseController
        , $cmsService
        , $routeParams
        , $location) {

        var vm = this;
        vm.newPage = null;
        vm.pageTemplateOptions = [{ TemplateId: 1, TemplateLabel: "Buyer" }, { TemplateId: 2, TemplateLabel: "Private Seller" }, { TemplateId: 3, TemplateLabel: "Dealership" }];

        vm.$cmsService = $cmsService;
        vm.$scope = $scope;

        vm.addPage = _addPage;
        vm.pagesId = $routeParams.pagesId;
        vm.newPage = $routeParams.newPage;

        $baseController.merge(vm, $baseController);

        vm.notify = vm.$cmsService.getNotifier($scope);

        render();

        // Upon page load, check to see if there is an Id
        function render() {
            if (vm.pagesId && vm.pagesId.length > 0) {
                vm.$cmsService.getPageById(vm.pagesId, _onGetPageSuccess, _onGetPageError);
            }
        };

        // On success of having an Id, populate the form with data associated with that Id
        function _onGetPageSuccess(response) {
            vm.notify(function () {
                vm.newPage = response.item;
            });
        };

        function _onGetPageError(jqXhr, error) {
            console.error(error);
        };

        // Create / Edit page
        function _addPage() {
            vm.showNewPageErrors = true;

            if (vm.pagesForm.$valid) {

                // Edit mode
                if (vm.pagesId && vm.pagesId.length > 0) {
                    vm.$cmsService.updatePages(vm.newPage, vm.pagesId, _onUpdatePageSuccess, _onUpdatePageError);
                }
                // Create new page mode
                else {
                    vm.$cmsService.addPage(vm.newPage, _onAddPageSuccess, _onAddPageError);
                }
            }          
        };

        // On success of updating an Id, it redirects to the full list view of pages
        function _onUpdatePageSuccess(response) {
            vm.notify(function (response) {
                vm.$alertService.success();
                $location.path('/');
                render();
            });
        };

        function _onUpdatePageError(jqXhr, error) {
            vm.$alertService.error();
        };

        // Upon success of creating a new page, the page changes to edit mode with the Id (in URL)
        function _onAddPageSuccess(response) {
            vm.$alertService.success();
            $location.path("/edit/" + response.item);
            render();
        };

        function _onAddPageError(jqXhr, error) {
            vm.$alertService.error();
        };


    }
})();
