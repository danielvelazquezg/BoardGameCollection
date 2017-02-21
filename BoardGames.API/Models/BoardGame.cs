using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace BoardGames.API.Models
{
    [XmlRoot("BoardGameCollection")]
    public class BoardGame
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "A board game name is required.")]
        [MinLength(4, ErrorMessage = "The board game name must be at least 4 characters in length.")]
        [MaxLength(20, ErrorMessage = "The board game name cannot exceed 20 characters in length.")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Range(0, 100, ErrorMessage = "")]
        public int PlayersMin { get; set; }
        [Range(0, 100)]
        public int PlayersMax { get; set; }
        [Range(0, 100)]
        public decimal Price { get; set; }
    }
}