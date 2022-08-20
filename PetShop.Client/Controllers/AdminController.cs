using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Client.Models;
using PetShop.Client.Services;
using PetShop.Data.Repositories;


namespace PetShop.Client.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ICatalogRepository _catalogRepository;
        private readonly IFileService _fileService;
        public AdminController(IAnimalRepository animalRepository,
            ICatalogRepository catalogRepository, IFileService fileService)
        {
            _animalRepository = animalRepository;
            _catalogRepository = catalogRepository;
            _fileService = fileService;
        }
     
        public async Task<IActionResult> Index(int id = 0)
        //Displays all animals or displays by category using the Selectlist
        //Displays all the animals by default
        {
            var animals = await _animalRepository.SelectCategory(id); ;
            ViewBag.Category = new SelectList(_catalogRepository.GetCategories(), "CategoryId", "Name", id);
            return View(animals);
        }
        [HttpGet]
        public async Task<IActionResult> DeleteAnimal(int id)
        {
            var animal = await _animalRepository.FindAnimalById(id);
            return View(animal);
        }

        [HttpPost,ActionName("DeleteAnimal")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var animal = await _animalRepository.DeleteAnimal(id);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditAnimal(int id)
        {
            var animal = await _animalRepository.FindAnimalById(id);
            ViewBag.Category = new SelectList(_catalogRepository.GetCategories(), "CategoryId", "Name");
            return View(new AnimalViewModel() { Animal = animal });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAnimal([FromForm] AnimalViewModel model)
        //Edit the animal with image(The function of the files located in the Service folder) The image is located at wwwroot
        {
            ModelState.Clear();

            _ = await _fileService.UploadOrEditAnimalsPhotos(model.Photo, model.Animal!);

            if (ModelState.IsValid)
            {
                await _animalRepository.EditAnimal(model.Animal!);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult CreateAnimal()
        {
            ViewBag.Category = new SelectList(_catalogRepository.GetCategories(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnimal([FromForm] AnimalViewModel model)
        //Adds a new animal with image(The function of the files located in the Service folder) The image is located at wwwroot
        {
            ModelState.Clear();

            await _fileService.UploadOrEditAnimalsPhotos(model.Photo, model.Animal!);

            if (ModelState.IsValid)
            {
                await _animalRepository.AddAnimal(model.Animal!);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }


}
