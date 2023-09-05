using MovieAPI_DAL.Models;

namespace MovieAPI_DAL.Repos
{
    public interface IPersonService
    {
        void CreatePerson(Person p);
        IEnumerable<Person> GetAll();
        Person GetById(int id);
        IEnumerable<PersonRole> GetRoleByMovieId(int id);
        void SetAsActor(int idPerson, int idMovie, string role);
    }
}