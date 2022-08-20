using Microsoft.AspNetCore.Mvc;
using PetShop.Client.Models;
using PetShop.Data.Repositories;
using System.Diagnostics;

namespace PetShop.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnimalRepository _animalRepository;
        public HomeController(ILogger<HomeController> logger, IAnimalRepository animalRepository)
        {
            _logger = logger;
            _animalRepository = animalRepository;
        }

        public async Task<IActionResult> Index()
        //Display the two animals with the most comments
        {
            var animal = _animalRepository.GetAnimalsByMostComments();
            return View(await animal);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}