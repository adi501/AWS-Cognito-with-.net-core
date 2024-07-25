using AWS_Cognito.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AWS_Cognito.Controllers
{
   // [Authorize]
    [Authorize(Policy = "AdminOnly")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {


            _logger = logger;
        }

        public IActionResult Index()
        {
            string accessToken = HttpContext.GetTokenAsync("access_token").Result;
            ViewData["access_token"] = accessToken;

            return View();
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