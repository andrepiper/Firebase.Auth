using Firebase.Auth.Middleware.Implementation;
using Firebase.Auth.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Firebase.Auth.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IFirebaseMiddleware _firebaseMiddleware;
        public HomeController(ILogger<HomeController> logger,
            IFirebaseMiddleware firebaseMiddleware)
        {
            _firebaseMiddleware = firebaseMiddleware;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var backendResponse = await _firebaseMiddleware.CreateUser(
                "user_xyz",
                "password123456@", 
                "user_xyz@gmail.com",
                "dre", 
                "+18761234567",
                "https://avatars.githubusercontent.com/u/3706993?v=4");
            return View(backendResponse);
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