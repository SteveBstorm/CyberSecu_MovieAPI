using MovieAPI_DAL.Models;

namespace MovieAPI_DAL.Repos
{
    public interface IUserService
    {
        IEnumerable<User> GetUsers();
        User LoginUser(string email, string password);
        void RegisterUser(string nickname, string email, string password);
        void SetRole(int idUser, int idRole);
    }
}