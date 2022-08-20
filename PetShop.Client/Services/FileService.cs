using PetShop.Data.Models;

namespace PetShop.Client.Services
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _environment;
        public FileService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }
        public async Task<string> UploadOrEditAnimalsPhotos(IFormFile file, Animal animal)
        {
            string wwwPath = _environment.WebRootPath;
            var path = Path.Combine(wwwPath, "Images", file.FileName);
            if (file.Length > 0)
            {
                using var stream = new FileStream(path, FileMode.Create);
                await file.CopyToAsync(stream);
            }
            return animal!.PhotoUrl = file.FileName; //Returns the url of the image that exists in wwwroot
        }
    }
}
