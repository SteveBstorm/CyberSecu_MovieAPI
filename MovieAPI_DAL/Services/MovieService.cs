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
    public class MovieService : IMovieService
    {
        private readonly IDbConnection _connection;
        public MovieService(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Movie> GetAll()
        {
            
            return _connection.Query<Movie>("SELECT * FROM Movie");
        }

        public Movie GetById(int id)
        {
            string sql = "SELECT * FROM Movie WHERE Id = @id";
            return _connection.QueryFirst<Movie>(sql, new { id });
        }

        public void CreateMovie(Movie movie)
        {
            string sql = "INSERT INTO Movie (Title, Synopsis, IdRealisator, IdGenre, IdScenarist, ReleaseYear, UrlPoster, UrlTrailer) " +
                " VALUES (@title, @synopsis, @idRealisator, @idGenre, @idScenarist, @releaseYear, @urlPoster, @urlTrailer)";
            _connection.Query(sql, movie);
        }

        public IEnumerable<Movie> GetByGenreId(int genreId)
        {
            string sql = "SELECT * FROM Movie WHERE IdGenre = @genreId";
            var param = new { genreId };
            return _connection.Query<Movie>(sql, param);
        }

        public IEnumerable<Movie> GetByRealId(int realId)
        {
            string sql = "SELECT * FROM Movie WHERE IdRealisator = @realId";
            var param = new { realId };
            return _connection.Query<Movie>(sql, param);
        }

        public IEnumerable<Movie> GetByScenaristId(int scenId)
        {
            string sql = "SELECT * FROM Movie WHERE IdScenarist = @scenId";
            var param = new { scenId };
            return _connection.Query<Movie>(sql, param);
        }

        public IEnumerable<Movie> GetByActorId(int actorId)
        {
            string sql = "SELECT * FROM Movie m " +
                "JOIN MoviePerson_Role mp ON m.Id = mp.IdMovie " +
                "WHERE mp.IdPerson = @actorId";
            var param = new { actorId };
            return _connection.Query<Movie>(sql, param);
        }
    }
}
