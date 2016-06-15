(function () {
    "use strict";

    angular.module(APPNAME)
        .config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {

            $routeProvider.when('/edit/:pagesId', {
                templateUrl: '/Scripts/sabio/application/cms/templates/index.html',
                controller: 'createPageController',
                controllerAs: 'cms'
            }).when('/create', {
                templateUrl: '/Scripts/sabio/application/cms/templates/index.html',
                controller: 'createPageController',
                controllerAs: 'cms'
            }).when('/', {
                templateUrl: '/Scripts/sabio/application/cms/templates/list.html',
                controller: 'pagesListController',
                controllerAs: 'cms'
           
            })

            $locationProvider.html5Mode(false);

        }]);

})();