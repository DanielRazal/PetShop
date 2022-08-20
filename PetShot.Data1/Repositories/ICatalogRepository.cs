using Microsoft.EntityFrameworkCore;
using PetShop.Data.Models;

namespace PetShop.Data.Repositories
{
    public interface ICatalogRepository
    {
        DbSet<Category> GetCategories();
    }
}