using ElevateWorkforceSolutionsJP.Areas.Identity.Data;
using ElevateWorkforceSolutionsJP.EntityModel;
using ElevateWorkforceSolutionsJP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ElevateWorkforceSolutionsJP.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ApplicationDBcontext _context;

        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationIDuser> _userManager;

        // Inject UserManager into the constructor
        public HomeController(ILogger<HomeController> logger, UserManager<ApplicationIDuser> userManager, ApplicationDBcontext context)

        {
            _logger = logger;
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Get the current logged-in user
            var currentUser = await _userManager.GetUserAsync(User);

            // Check if user is authenticated and get the first letter of the username
            if (currentUser != null)
            {
                var firstLetter = currentUser.UserName?.FirstOrDefault().ToString().ToUpper(); // Get first letter and make it uppercase
                ViewBag.FirstLetter = firstLetter;
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult JobListings()
        {
            var jobPostings = _context.Joblists.ToList();
            var jobApplications = _context.JobApplications.ToList();

            var viewModel = new DashboardViewModel
            {
                JobPostings = jobPostings,
                JobApplications = jobApplications
            };

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
