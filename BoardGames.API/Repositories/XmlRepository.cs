using BoardGames.API.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Xml.Serialization;

namespace BoardGames.API.Repositories
{
    public class XmlRepository : IBoardGameRepository
    {
        private const string VIRTUAL_PATH = @"~/App_Data/boardGameCollection.xml";

        public BoardGame Create()
        {
            return new BoardGame();
        }

        public List<BoardGame> Retrieve()
        {
            var filePath = HostingEnvironment.MapPath(VIRTUAL_PATH);

            //Added only for Unit Testing puroposes
            if (filePath == null)
                filePath = @"C:\Users\Daniel VG\Documents\Visual Studio 2015\Projects\BoardGames\BoardGames.API\App_Data\boardGameCollection.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BoardGameCollection));
            BoardGameCollection boardGameCollection;
            using (FileStream myFileStream = new FileStream(filePath, FileMode.Open))
            {
                boardGameCollection = (BoardGameCollection)xmlSerializer.Deserialize(myFileStream);
            }
            return boardGameCollection.BoardGameList;
        }

        public BoardGame Save(BoardGame boardGame)
        {
            var boardGames = this.Retrieve();

            boardGames.Add(boardGame);

            WriteData(boardGames);

            return boardGame;
        }

        public BoardGame Save(Guid id, BoardGame boardGame)
        {
            var boardGames = this.Retrieve();
            var existingBoardGame = boardGames.FirstOrDefault(bg => bg.Id == id);
            if (existingBoardGame == null)
                return null;

            existingBoardGame.Name = boardGame.Name;
            existingBoardGame.Description = boardGame.Description;
            existingBoardGame.PlayersMin = boardGame.PlayersMin;
            existingBoardGame.PlayersMax = boardGame.PlayersMax;
            existingBoardGame.Price = boardGame.Price;
            
            WriteData(boardGames);

            return boardGame;
        }

        public bool Delete(Guid id)
        {
            var boardGames = this.Retrieve();
            var existingBoardGame = boardGames.FirstOrDefault(bg => bg.Id == id);
            if (existingBoardGame == null)
                return false;

            boardGames.Remove(existingBoardGame);
            WriteData(boardGames);

            return true;
        }

        private void WriteData(List<BoardGame> boardGames)
        {
            var filePath = HostingEnvironment.MapPath(VIRTUAL_PATH);

            //Added only for Unit Testing puroposes
            if (filePath == null)
                filePath = @"C:\Users\Daniel VG\Documents\Visual Studio 2015\Projects\BoardGames\BoardGames.API\App_Data\boardGameCollection.xml";

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(BoardGameCollection));

            using (FileStream stream = new FileStream(filePath, FileMode.Create))
            {
                xmlSerializer.Serialize(stream, new BoardGameCollection { BoardGameList = boardGames });
            }
        }
    }
}