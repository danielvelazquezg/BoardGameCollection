(function () {
    "use strict";
    
    var app = angular.module("ngBoardGames",
                            ["boardGame.service",
                             "ngRoute"]);

    app.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/", {
                templateUrl: "app/boardGames/listView.html",
                controller: "listCtrl as vm"
            })
            .when("/edit/:id", {
                templateUrl: "app/boardGames/editView.html",
                controller: "editCtrl as vm"
            })
            .when("/new/", {
                templateUrl: "app/boardGames/editView.html",
                controller: "editCtrl as vm"
            })
        }
    );
}());