using ElevateWorkforceSolutionsJP.Areas.Identity.Data;
using ElevateWorkforceSolutionsJP.EntityModel;
using ElevateWorkforceSolutionsJP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

public class JoblistController : Controller
{
    private readonly ApplicationDBcontext _context;

    public JoblistController(ApplicationDBcontext context)
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

    // Ensure only one [HttpPost] attribute
    [HttpPost]
    public async Task<IActionResult> Create(JoblistViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        // Map the ViewModel to the Entity
        var joblist = new Joblist
        {
            JobTitle = model.JobTitle,
            JobOrganization = model.JobOrganization,
            JobDescription = model.JobDescription,
            HRContact = model.HRContact,
            WorkingHours = model.WorkingHours,
            Salary = model.Salary
        };

        // Add the joblist to the database
        _context.Joblists.Add(joblist);
        await _context.SaveChangesAsync();

        // Redirect to the Index action or any success page
        return RedirectToAction("Index", "Dashboard");
    }

    // Edit and Delete actions

    public IActionResult Edit(int id)
    {
        var job = _context.Joblists.Find(id);
        if (job == null)
        {
            return NotFound();
        }

        // Map the Joblist entity to the ViewModel
        var model = new JoblistViewModel
        {
            JobId = job.JobId,
            JobTitle = job.JobTitle,
            JobOrganization = job.JobOrganization,
            JobDescription = job.JobDescription,
            HRContact = job.HRContact,
            WorkingHours = job.WorkingHours,
            Salary = job.Salary
        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, JoblistViewModel model)
    {
        if (id != model.JobId)
        {
            return NotFound();
        }

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var job = await _context.Joblists.FindAsync(id);
        if (job == null)
        {
            return NotFound();
        }

        // Update the fields
        job.JobTitle = model.JobTitle;
        job.JobOrganization = model.JobOrganization;
        job.JobDescription = model.JobDescription;
        job.HRContact = model.HRContact;
        job.WorkingHours = model.WorkingHours;
        job.Salary = model.Salary;

        try
        {
            _context.Update(job);
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Joblists.Any(j => j.JobId == job.JobId))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        // Redirect to the list or success page
        return RedirectToAction("Index", "Dashboard");
    }

    public async Task<IActionResult> Delete(int id)
    {
        // Retrieve the job listing by ID
        var job = await _context.Joblists.FindAsync(id);
        if (job == null)
        {
            return NotFound();
        }

        // Remove the job listing
        _context.Joblists.Remove(job);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index", "Dashboard");
    }
}
