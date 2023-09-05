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
    public class CommentService : ICommentService
    {
        private readonly IDbConnection _connection;
        public CommentService(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Comment> GetComments(int movieId)
        {
            string sql = "SELECT * FROM Comments WHERE IdMovie = @movieId";
            var param = new { movieId };
            return _connection.Query<Comment>(sql, param);
        }

        public void AddComment(Comment comment)
        {
            string sql = "INSERT INTO Comments (Content, PostDate, IdUser, IdMovie) " +
                "VALUES (@Content, @PostDate, @IdUser, @IdMovie)";
            _connection.Execute(sql, comment);
        }
    }
}
