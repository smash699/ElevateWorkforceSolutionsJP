using ElevateWorkforceSolutionsJP.EntityModel;
using System.Collections.Generic;

namespace ElevateWorkforceSolutionsJP.Models
{
    public class DashboardViewModel
    {
        public List<Joblist> JobPostings { get; set; }
        public List<JobApplication> JobApplications { get; set; }
    }
}
