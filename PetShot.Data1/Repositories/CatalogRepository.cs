using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.Models;

namespace PetShop.Data.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly PetShopDbContext _context;

        public CatalogRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public DbSet<Category> GetCategories()
        {
            var category = _context.Categories;
            return category;
        }
    }
}
