using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MovieAPI_DAL.Models;
using MovieAPI_DAL.Repos;

namespace MovieAPI_DAL.Services
{
    public class UserService : IUserService
    {
        private readonly IDbConnection _connection;

        public UserService(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<User> GetUsers()
        {
            string sql = "SELECT * FROM Users";
            return _connection.Query<User>(sql);
        }

        public void RegisterUser(string nickname, string email, string password)
        {
            string sql = "INSERT INTO Users (Nickname, Email, HashPWD)" +
                " VALUES (@nickname, @email, @password)";
            var param = new { nickname, email, password };
            _connection.Execute(sql, param);

        }

        public User LoginUser(string email, string password)
        {
            try
            {
                string sql = "SELECT * FROM Users WHERE Email = @email AND " +
                    "HashPWD = @password";
                var param = new { email, password };
                return _connection.QueryFirst<User>(sql, param);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Utilisateur inéxistant");
            }
        }

        public void SetRole(int idUser, int idRole)
        {
            string sql = "UPDATE Users SET IdRole = @idRole WHERE Id = @idUser";
            var param = new { idUser, idRole };
            _connection.Execute(sql, param);
        }
    }
}
