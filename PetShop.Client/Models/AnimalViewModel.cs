using PetShop.Data.Models;

namespace PetShop.Client.Models
{
    public class AnimalViewModel
    {
        public Animal? Animal { get; set; }
        public IFormFile Photo { get; set; }
    }
}
