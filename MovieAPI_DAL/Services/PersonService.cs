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
    public class PersonService : IPersonService
    {
        private readonly IDbConnection _connection;
        public PersonService(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Person> GetAll()
        {
            return _connection.Query<Person>("SELECT * FROM Person");
        }

        public Person GetById(int id)
        {
            string sql = "SELECT * FROM Person WHERE Id = @id";
            return _connection.QueryFirst<Person>(sql, new { id });
        }

        public void CreatePerson(Person p)
        {
            string sql = "INSERT INTO Person (Firstname, Lastname, ImageUrl) " +
                " VALUES (@firstname, @lastname, @imageUrl)";
            _connection.Query(sql, p);
        }

        public void SetAsActor(int idPerson, int idMovie, string role)
        {
            string sql = "INSERT INTO MoviePerson_Role (IdPerson, IdMovie, Role) " +
                "VALUES (@idPerson, @idRole, @role)";

            _connection.Execute(sql, new { idPerson, idMovie, role });
        }

        public IEnumerable<PersonRole> GetRoleByMovieId(int id)
        {
            string sql = "SELECT * FROM MoviePerson_Role WHERE IdMovie = @id";
            return _connection.Query<PersonRole>(sql, new { id });
        }

    }
}
