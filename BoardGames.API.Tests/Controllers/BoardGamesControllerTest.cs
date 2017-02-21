using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoardGames.API;
using BoardGames.API.Controllers;
using System.Web.Http.Results;
using System.Web.Http.Routing;

namespace BoardGames.API.Tests.Controllers
{
    [TestClass]
    public class BoardGamesControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            BoardGamesController controller = new BoardGamesController();

            // Act
            var result = controller.Get() as OkNegotiatedContentResult<List<Models.BoardGame>>;

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Content.Count() > 0);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            BoardGamesController controller = new BoardGamesController();
            controller.Request = new HttpRequestMessage
             {
                 RequestUri = new Uri("http://localhost:51010/api/boardGames")
             };
            controller.Configuration = new HttpConfiguration();
            controller.Configuration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            controller.RequestContext.RouteData = new HttpRouteData(
                route: new HttpRoute(),
                values: new HttpRouteValueDictionary { { "controller", "boardGames" } });
            
            // Act
            int originalCount = (controller.Get() as OkNegotiatedContentResult<List<Models.BoardGame>>)
                .Content.Count();

            var newBoardGame = new Models.BoardGame
            {
                Name = "Klondike",
                Description = "Klondike is a patience game (solitaire card game). In the U.S. and Canada, Klondike is known as solitaire, being one of the better known of the family of patience games. The game rose to fame in the late 19th century, being named 'Klondike' after the Canadian region where a gold rush happened. It is rumored that the game was either created or popularized by the prospectors in Klondike.",
                PlayersMax = 1,
                PlayersMin = 1,
                Price = 0.99M
            };

            var response = controller.Post(newBoardGame) as CreatedNegotiatedContentResult<Models.BoardGame>;

            int newCount = (controller.Get() as OkNegotiatedContentResult<List<Models.BoardGame>>)
                .Content.Count();
            
            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(++originalCount, newCount);
            Assert.AreEqual(newBoardGame, response.Content);
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            BoardGamesController controller = new BoardGamesController();

            // Act
            var boardGames = (controller.Get() as OkNegotiatedContentResult<List<Models.BoardGame>>).Content;
            var boardGame = boardGames.FirstOrDefault();

            boardGame.Name = "This is a new name";
            boardGame.Description = "This is a new description";

            var response = (controller.Put(boardGame.Id, boardGame) as OkNegotiatedContentResult<Models.BoardGame>).Content;

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(boardGame, response);
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            BoardGamesController controller = new BoardGamesController();

            // Act
            var boardGames = (controller.Get() as OkNegotiatedContentResult<List<Models.BoardGame>>).Content;
            var boardGame = boardGames.FirstOrDefault();

            int originalCount = (controller.Get() as OkNegotiatedContentResult<List<Models.BoardGame>>)
                .Content.Count();

            var response = controller.Delete(boardGame.Id) as OkResult;

            int newCount = (controller.Get() as OkNegotiatedContentResult<List<Models.BoardGame>>)
                .Content.Count();

            // Assert
            Assert.IsNotNull(response);
            Assert.AreEqual(--originalCount, newCount);
        }
    }
}
