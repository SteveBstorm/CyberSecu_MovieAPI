using MovieAPI_DAL.Models;

namespace MovieAPI_DAL.Repos
{
    public interface ICommentService
    {
        void AddComment(Comment comment);
        IEnumerable<Comment> GetComments(int movieId);
    }
}