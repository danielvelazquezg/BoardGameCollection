(function () {
    "use strict";
    angular
        .module("ngBoardGames")
        .controller("listCtrl",
                     ["boardGameResource",
                         listCtrl]);

    function listCtrl(boardGameResource) {
        var vm = this;

        boardGameResource.query(function (data) {
            vm.boardGames = data;
        });

        vm.delete = function (boardGameId) {
            boardGameResource.delete({ id: boardGameId },
                function () {
                    boardGameResource.query(function (data) {
                        vm.boardGames = data;
                    });
                });
        };
        //vm.boardGames = [
        //    {
        //        "code": 1,
        //        "name": "Chess",
        //        "description": "",
        //        "playersMin": 2,
        //        "playersMax": 2,
        //        "price": 15.99
        //    },
        //    {
        //        "code": 2,
        //        "name": "Monopoly",
        //        "description": "",
        //        "playersMin": 2,
        //        "playersMax": 2,
        //        "price": 15.99
        //    },
        //    {
        //        "code": 3,
        //        "name": "Scrabble",
        //        "description": "",
        //        "playersMin": 2,
        //        "playersMax": 2,
        //        "price": 15.99
        //    },
        //    {
        //        "code": 4,
        //        "name": "Risk",
        //        "description": "",
        //        "playersMin": 2,
        //        "playersMax": 2,
        //        "price": 15.99
        //    },
        //    {
        //        "code": 5,
        //        "name": "Clue",
        //        "description": "",
        //        "playersMin": 2,
        //        "playersMax": 2,
        //        "price": 15.99
        //    },
        //    {
        //        "code": 6,
        //        "name": "Uno",
        //        "description": "",
        //        "playersMin": 2,
        //        "playersMax": 2,
        //        "price": 15.99
        //    },
        //    {
        //        "code": 7,
        //        "name": "Checkers",
        //        "description": "",
        //        "playersMin": 2,
        //        "playersMax": 2,
        //        "price": 15.99
        //    },
        //    {
        //        "code": 8,
        //        "name": "Backgammon",
        //        "description": "",
        //        "playersMin": 2,
        //        "playersMax": 2,
        //        "price": 15.99
        //    },
        //    {
        //        "code": 9,
        //        "name": "Pictionary",
        //        "description": "",
        //        "playersMin": 2,
        //        "playersMax": 2,
        //        "price": 15.99
        //    },
        //    {
        //        "code": 10,
        //        "name": "Guess Who?",
        //        "description": "",
        //        "playersMin": 2,
        //        "playersMax": 2,
        //        "price": 15.99
        //    }];
    };

}());