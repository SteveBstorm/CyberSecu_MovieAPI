using Dapper;
using MovieAPI_DAL.Models;
using MovieAPI_DAL.Repos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieAPI_DAL.Services
{
    public class GenreService : IGenreService
    {
        private readonly IDbConnection _connection;
        public GenreService(IDbConnection connection)
        {
            _connection = connection;
        }

        public void CreateGenre(string genre)
        {
            string sql = "INSERT INTO Genre (Label) VALUES (@genre)";
            _connection.Execute(sql, new { genre });
        }

        public IEnumerable<Genre> GetAll()
        {
            return _connection.Query<Genre>("SELECT * FROM Genre");
        }
    }
}
