using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.Models;

namespace PetShot.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly PetShopDbContext _context;

        public CommentRepository(PetShopDbContext context)
        {
            _context = context;
        }
        public async Task<int> AddComment(Comment comment,int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            comment.Animal = animal!;
            _context.Add(comment);
            return await _context.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetCommentsById(int id)
        {
            var comments = _context.Comments.Where(a => a.AnimalId == id).ToList();
            return comments;
        }
    }
}
