
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

        function render() {
            if (vm.pagesId && vm.pagesId.length > 0) {
                vm.$cmsService.getPageById(vm.pagesId, _onGetPageSuccess, _onGetPageError);
            }
        };

        function _onGetPageSuccess(response) {
            vm.notify(function () {
                vm.newPage = response.item;
            });
        };

        function _onGetPageError(jqXhr, error) {
            console.error(error);
        };

        function _addPage() {
            vm.showNewPageErrors = true;

            if (vm.pagesForm.$valid) {

                if (vm.pagesId && vm.pagesId.length > 0) {
                    vm.$cmsService.updatePages(vm.newPage, vm.pagesId, _onUpdatePageSuccess, _onUpdatePageError);
                }
                else {
                    vm.$cmsService.addPage(vm.newPage, _onAddPageSuccess, _onAddPageError);
                }
            }          
        };

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
