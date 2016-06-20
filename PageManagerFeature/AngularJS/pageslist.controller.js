(function () {
    "use strict";

    angular.module(APPNAME)
        .controller('pagesListController', PagesListController);

    PagesListController.$inject = ['$scope', '$baseController', "$cmsService"];

    function PagesListController(
        $scope
        , $baseController
        , $cmsService) {

        var vm = this;
        vm.pages = null;

        vm.$cmsService = $cmsService;
        vm.$scope = $scope;

        vm.deletePagesById = _deletePagesById;

        $baseController.merge(vm, $baseController);

        vm.notify = vm.$cmsService.getNotifier($scope);

        render();

        // GET Ajax call for Index (list of pages by Id) 
        function render() {
            vm.$cmsService.loadJson(_onAjaxSuccess, _onAjaxError);
        };

        // Upon success, full list of JSON data renders
        function _onAjaxSuccess(data) {           
            vm.notify(function () {
                vm.pages = data.items;
            });
        };

        function _onAjaxError(jqXhr, error) {
            vm.$alertService.error();
        };

        // DELETE Ajax call by pagesId
        function _deletePagesById(pagesId) {
            vm.$cmsService.deletePagesById(pagesId, _onDeleteSuccess, _onDeleteError);
        };

        // On success the Id is removed from the list
        function _onDeleteSuccess() {
            render();
        };

        function _onDeleteError(jqXhr, error) {
            vm.$alertService.error();
        };

    }
})();
