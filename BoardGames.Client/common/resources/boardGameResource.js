(function () {
    "use strict";

    angular.module("boardGame.service")
           .factory("boardGameResource",
                    ["$resource",
                     "appSettings",
                     boardGameResource])

    function boardGameResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "api/boardGames/:id", null,
                {
                    'update': { method: 'PUT' }
                });
    }
}());