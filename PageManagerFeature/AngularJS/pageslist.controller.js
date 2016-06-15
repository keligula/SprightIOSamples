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

        function render() {
            vm.$cmsService.loadJson(_onAjaxSuccess, _onAjaxError);
        };

        function _onAjaxSuccess(data) {           
            vm.notify(function () {
                vm.pages = data.items;
            });
        };

        function _onAjaxError(jqXhr, error) {
            vm.$alertService.error();
        };

        function _deletePagesById(pagesId) {
            vm.$cmsService.deletePagesById(pagesId, _onDeleteSuccess, _onDeleteError);
        };

        function _onDeleteSuccess() {
            render();
        };

        function _onDeleteError(jqXhr, error) {
            vm.$alertService.error();
        };

    }
})();