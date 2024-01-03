using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging; // If using logging

namespace JobHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger; // For logging

        // Constructor for dependency injection (optional)
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Returns the main page of the application
        public IActionResult Index()
        {
            ViewData["Title"] = "JobHub - Home"; // Dynamic title
            return View();
        }

        // Returns a secondary page or action result
        [Route("home/second-action")] // Optional route attribute
        public IActionResult SecondAction()
        {
            _logger.LogInformation("Accessed SecondAction"); // Logging (optional)
            return Content("Why wait? Kickstart your career with JobHub today.");
        }

        // Generic error handler action
        public IActionResult Error()
        {
            ViewData["ErrorMessage"] = "An unexpected error occurred."; // Error message
            return View();
        }
    }
}
