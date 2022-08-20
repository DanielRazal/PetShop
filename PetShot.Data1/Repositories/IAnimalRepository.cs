using Microsoft.EntityFrameworkCore.ChangeTracking;
using PetShop.Data.Models;

namespace PetShop.Data.Repositories
{
    public interface IAnimalRepository
    {
        Task<IEnumerable<Animal>> SelectCategory(int id);
        Task<Animal> FindAnimalById(int id);

        Task<Animal> DeleteAnimal(int id);

        Task<int> AddAnimal(Animal animal);
        Task<int> EditAnimal(Animal animal);

        Task<IEnumerable<Animal>> GetAnimalsByMostComments();
    }
}