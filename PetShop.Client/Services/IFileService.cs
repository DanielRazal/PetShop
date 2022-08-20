using PetShop.Data.Models;

namespace PetShop.Client.Services
{
    public interface IFileService
    {
        Task<string> UploadOrEditAnimalsPhotos(IFormFile file, Animal animal);
    }
}
