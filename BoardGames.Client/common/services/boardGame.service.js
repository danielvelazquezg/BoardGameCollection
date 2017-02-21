(function () {
	"use strict";

	angular.module("boardGame.service",
					["ngResource"])
		   .constant("appSettings",
			{
				serverPath: "http://localhost:51010/"
			});
}());