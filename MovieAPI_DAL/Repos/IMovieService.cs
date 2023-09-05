using MovieAPI_DAL.Models;

namespace MovieAPI_DAL.Repos
{
    public interface IMovieService
    {
        void CreateMovie(Movie movie);
        IEnumerable<Movie> GetAll();
        Movie GetById(int id);
        IEnumerable<Movie> GetByGenreId(int genreId);
        IEnumerable<Movie> GetByRealId(int realId);
        IEnumerable<Movie> GetByScenaristId(int scenId);
        IEnumerable<Movie> GetByActorId(int actorId);
    }
}