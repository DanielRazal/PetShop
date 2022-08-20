using PetShop.Data.Models;

namespace PetShot.Data.Repositories
{
    public interface ICommentRepository
    {
        Task<int> AddComment(Comment comment,int id);
        IEnumerable<Comment> GetCommentsById(int id);
    }
}