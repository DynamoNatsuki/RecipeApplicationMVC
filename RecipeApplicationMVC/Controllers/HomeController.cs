using Microsoft.AspNetCore.Mvc;
using RecipeApplicationMVC.Models;
using System.Diagnostics;
using Database;

namespace RecipeApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Database.Database db = new Database.Database();
            List<Recipe> recipes = await db.GetAllRecipes();
            return View(recipes);
        }

        public async Task<IActionResult> Details(string id)
        {
            Database.Database db = new Database.Database();
            Recipe recipe = await db.GetRecipeById(id);
            return View(recipe);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
