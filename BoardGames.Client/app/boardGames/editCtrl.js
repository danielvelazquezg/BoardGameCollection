(function () {
    "use strict";

    angular.module("ngBoardGames")
           .controller("editCtrl",
            editCtrl);
    
    function editCtrl(boardGameResource, $routeParams) {
        var vm = this;
        vm.boardGame = {};
        vm.message = '';
        var boardGameId = '00000000-0000-0000-0000-000000000000';
        if ($routeParams.id)
            boardGameId = $routeParams.id;

        boardGameResource.get({ id: boardGameId },
            function (data) {
                vm.boardGame = data;
                vm.originalBoardGame = angular.copy(data);
            });
        
        if (vm.boardGame && vm.boardGame.id) {
            vm.title = "Edit: " + vm.boardGame.name;
        }
        else {
            vm.title = "New Board Game"
        }

        vm.submit = function () {
            vm.message = '';
            if (vm.boardGame.id && vm.boardGame.id !== '00000000-0000-0000-0000-000000000000') {
                vm.boardGame.$update({id: vm.boardGame.id},
                    function(data) {
                        vm.message = '... Save Complete';
                    },
                    function (response) {
                        vm.message = response.statusText + '\r\n';
                        if (response.data.modelState) {
                            for (var key in response.data.modelState) {
                                vm.message += respone.data.modelState[key] + '\r\n';
                            }
                        }
                        if (response.data.exceptionMessage)
                            vm.message += response.data.exceptionMessage;
                    })
            }
            else {
                vm.boardGame.$save(
                    function(data) {
                        vm.originalBoardGame = angular.copy(data);

                        vm.message = '... Save Complete';
                    },
                    function (response) {
                        vm.message = response.statusText + '\r\n';
                        if (response.data.exceptionMessage)
                            vm.message += response.data.exceptionMessage;
                    })
            }
        };

        vm.cancel = function (editForm) {
            editForm.$setPristine();
            vm.boardGame = angular.copy(vm.originalBoardGame);
            vm.message = '';
        };
    };
}());