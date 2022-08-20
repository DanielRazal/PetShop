using Microsoft.EntityFrameworkCore;
using PetShop.Data.Contexts;
using PetShop.Data.Models;

namespace PetShop.Data.Repositories
{
    public class AnimalRepository : IAnimalRepository
    {
        private readonly PetShopDbContext _context;

        public AnimalRepository(PetShopDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Animal>> SelectCategory(int id) 
            //Displays all animals or displays by category
        {
            List<Animal> data = new();
            var animal = _context.Animals.Include(a => a.Category);

            if (id > 0)
            {
                data = await animal.Where(c => c.Category!.CategoryId == id).ToListAsync();
            }
            else
            {
                data = await animal.ToListAsync();
            }
            return data;
        }

        public async Task<Animal> FindAnimalById(int id)
        {
            var animal = await _context.Animals.FindAsync(id);
            return animal!;
        }

        public async Task<Animal> DeleteAnimal(int id)
        // First delete the animal's comments and then delete the animal
        {
            var animal = await FindAnimalById(id);
            animal!.Comments.Clear();
            _context.Animals.Remove(animal!);
            await _context.SaveChangesAsync();
            return animal!;
        }

        public async Task<int> AddAnimal(Animal animal)
        {
            _context.Add(animal!);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> EditAnimal(Animal animal)
        {
            _context.Update(animal);
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Animal>> GetAnimalsByMostComments()
        //Sort the Comments in reverse order by the Count of messages and take 2 of them
        {
           var animal = _context.Animals.Include(c => c.Comments).OrderByDescending(c => c.Comments.Count).Take(2);
           return await animal.ToListAsync();
        }
    }
}