using ElevateWorkforceSolutionsJP.EntityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ElevateWorkforceSolutionsJP.Models;

namespace ElevateWorkforceSolutionsJP.Areas.Identity.Data;

public class ApplicationDBcontext : IdentityDbContext<ApplicationIDuser>
{
    public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options)
        : base(options)
    {

    }
    public DbSet<JobApplication> JobApplications { get; set; }
    public DbSet<Joblist> Joblists { get; set; }
    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

public DbSet<ElevateWorkforceSolutionsJP.Models.JoblistViewModel> JoblistViewModel { get; set; } = default!;

public DbSet<ElevateWorkforceSolutionsJP.Models.JobApplicationViewModel> JobApplicationViewModel { get; set; } = default!;
}
