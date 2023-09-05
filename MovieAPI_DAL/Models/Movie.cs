using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI_DAL.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public int IdGenre { get; set; }
        public int IdRealisator { get; set; }
        public int IdScenarist { get; set; }
        public int ReleaseYear { get; set; }
        public string UrlPoster { get; set; } 
        public string UrlTrailer { get; set; }
    }
}
