using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace BoardGames.API.Models
{
    public class BoardGameCollection 
    {
        [XmlArray("BoardGameList"), XmlArrayItem(typeof(BoardGame), ElementName = "BoardGame")]
        public List<BoardGame> BoardGameList { get; set; }
    }
}