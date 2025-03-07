using ElevateWorkforceSolutionsJP.Areas.Identity.Data;
using ElevateWorkforceSolutionsJP.EntityModel;
using ElevateWorkforceSolutionsJP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElevateWorkforceSolutionsJP.Controllers
{
    public class JobApplicationController : Controller
    {
        private readonly ApplicationDBcontext _context;

        public JobApplicationController(ApplicationDBcontext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(JobApplicationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var jobApplication = new JobApplication
            {
                FirstName=model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Age = model.Age,
                PhoneNumber = model.PhoneNumber,
                AcademicQualification = model.AcademicQualification,
                JobTitle = model.JobTitle,
                OrganizationName = model.OrganizationName
            };
            _context.JobApplications.Add(jobApplication);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Edit(int id)
        {
            // Find the job application by its ApplicationId
            var application = _context.JobApplications.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            // Map the JobApplication entity to the ViewModel
            var model = new JobApplicationViewModel
            {
                ApplicationId = application.ApplicationId,
                FirstName = application.FirstName,
                LastName = application.LastName,
                Email = application.Email,
                Age = application.Age,
                PhoneNumber = application.PhoneNumber,
                AcademicQualification = application.AcademicQualification,
                JobTitle = application.JobTitle,
                OrganizationName = application.OrganizationName
            };

            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, JobApplicationViewModel model)
        {
            if (id != model.ApplicationId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var application = await _context.JobApplications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            // Update the fields of the JobApplication entity with the values from the ViewModel
            application.FirstName = model.FirstName;
            application.LastName = model.LastName;
            application.Email = model.Email;
            application.Age = model.Age;
            application.PhoneNumber = model.PhoneNumber;
            application.AcademicQualification = model.AcademicQualification;
            application.JobTitle = model.JobTitle;
            application.OrganizationName = model.OrganizationName;

            try
            {
                // Explicitly set the entity state to Modified to track changes
                _context.Entry(application).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.JobApplications.Any(a => a.ApplicationId == application.ApplicationId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Redirect to the Index or any success page
            return RedirectToAction("Index", "JobApplication");
        }
        public IActionResult Delete(int id)
        {
            // Find the job application by its ApplicationId
            var application = _context.JobApplications.Find(id);
            if (application == null)
            {
                return NotFound();
            }

            // Map the JobApplication entity to the ViewModel
            var model = new JobApplicationViewModel
            {
                ApplicationId = application.ApplicationId,
                FirstName = application.FirstName,
                LastName = application.LastName,
                Email = application.Email,
                Age = application.Age,
                PhoneNumber = application.PhoneNumber,
                AcademicQualification = application.AcademicQualification,
                JobTitle = application.JobTitle,
                OrganizationName = application.OrganizationName
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var application = await _context.JobApplications.FindAsync(id);
            if (application == null)
            {
                return NotFound();
            }

            // Delete the job application
            _context.JobApplications.Remove(application);
            await _context.SaveChangesAsync();

            // Redirect to the list or success page
            return RedirectToAction("Index", "JobApplication");
        }

    }
}
