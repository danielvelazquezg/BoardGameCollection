using BoardGames.API.Models;
using BoardGames.API.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;

namespace BoardGames.API.Controllers
{
    [EnableCors("http://localhost:50458", "*","*")]
    public class BoardGamesController : ApiController
    {
        [ResponseType(typeof(List<BoardGame>))]
        public IHttpActionResult Get()
        {
            try
            {
                var repository = RepositoryFactory.Repository;

                return Ok(repository.Retrieve());
            }
            catch (Exception ex)
            {
                //This is in case the file is being used by another process
                return InternalServerError(ex);
            }
        }

        [ResponseType(typeof(BoardGame))]
        public IHttpActionResult Get(Guid id)
        {
            try
            { 
                var boardGame = RepositoryFactory.Repository
                    .Retrieve()
                    .FirstOrDefault(bg => bg.Id == id);
                if (boardGame == null || boardGame.Id == new Guid())
                    return Ok(new BoardGame());

                return Ok(boardGame);
            }
            catch (Exception ex)
            {
                //This is in case the file is being used by another process
                return InternalServerError(ex);
            }
        }

        // POST: api/BoardGames
        public IHttpActionResult Post([FromBody]BoardGame boardGame)
        {
            try
            {
                if (boardGame == null)
                    return BadRequest("Board Game cannot be null");
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                boardGame.Id = Guid.NewGuid();

                var repository = RepositoryFactory.Repository;
                var newBoardGame = repository.Save(boardGame);
                if (newBoardGame == null)
                    return Conflict();

                return Created<BoardGame>(Request.RequestUri + newBoardGame.Id.ToString(), newBoardGame);
            }
            catch (Exception ex)
            {
                //This is in case the file is being used by another process
                return InternalServerError(ex);
            }
        }

        // PUT: api/BoardGames/5
        public IHttpActionResult Put(Guid id, [FromBody]BoardGame boardGame)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (boardGame == null)
                    return BadRequest("Board Game cannot be null");

                var repository = RepositoryFactory.Repository;
                var newBoardGame = repository.Save(id, boardGame);
                if (newBoardGame == null || newBoardGame.Id == new Guid())
                    return NotFound();

                return Ok(boardGame);
            }
            catch (Exception ex)
            {
                //This is in case the file is being used by another process
                return InternalServerError(ex);
            }
        }

        // DELETE: api/BoardGames/5
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                var repository = RepositoryFactory.Repository;
                if (!repository.Delete(id))
                    return NotFound();

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
