using MovieAPI_DAL.Models;

namespace MovieAPI_DAL.Repos
{
    public interface IGenreService
    {
        void CreateGenre(string genre);
        IEnumerable<Genre> GetAll();
    }
}