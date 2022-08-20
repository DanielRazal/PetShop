using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Client.Models;
using PetShop.Data.Models;
using PetShop.Data.Repositories;
using PetShot.Data.Repositories;

namespace PetShop.Client.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly ICatalogRepository _catalogRepository;
        private readonly ICommentRepository _commentRepository;
        public CatalogController(IAnimalRepository animalRepository,
            ICatalogRepository catalogRepository, ICommentRepository commentRepository)
        {
            _animalRepository = animalRepository;            
            _catalogRepository = catalogRepository;
            _commentRepository = commentRepository;
        }
        public async Task<IActionResult> Index(int id = 0)
        //Displays all animals or displays by category using the Selectlist
        //Displays all the animals by default
        {
            var animals = await _animalRepository.SelectCategory(id);
            ViewBag.Category = new SelectList(_catalogRepository.GetCategories(), "CategoryId", "Name", id);
            return View(animals);
        }
        public async Task<IActionResult> DetailsAnimal(int id)
        //Makes join between table of animals and comments using AddCommentViewModel to add comments to each animal
        {
            var animal = await _animalRepository.FindAnimalById(id);
            return View(new AddCommentViewModel() {Animal = animal ,
            Comments = _commentRepository.GetCommentsById(id)});
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DetailsAnimal(Comment comment, int id)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                await _commentRepository.AddComment(comment,id);
                return RedirectToAction(nameof(DetailsAnimal));
            }
            return View();
        }
    }
}