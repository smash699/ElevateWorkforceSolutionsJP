using ElevateWorkforceSolutionsJP.Areas.Identity.Data;
using ElevateWorkforceSolutionsJP.EntityModel;
using ElevateWorkforceSolutionsJP.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ElevateWorkforceSolutionsJP.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ApplicationDBcontext _context;

        public DashboardController(ApplicationDBcontext context)
        {
            _context = context;
        }

        public IActionResult Index()
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
        public IActionResult JobPostings()
        {
            var jobPostings = _context.Joblists.ToList();
            var viewModel = new DashboardViewModel
            {
                JobPostings = jobPostings
            };

            return View(viewModel);
        }
        public IActionResult JobApplication()
        {
            var jobApplications = _context.JobApplications.ToList();
            var viewModel = new DashboardViewModel
            {
                JobApplications = jobApplications
            };

            return View(viewModel);
        }

    }
}
