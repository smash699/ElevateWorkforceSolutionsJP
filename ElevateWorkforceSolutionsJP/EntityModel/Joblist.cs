using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace ElevateWorkforceSolutionsJP.EntityModel
{
    
   public class Joblist: Common
    {
        [Key]
        public int JobId { get; set; }

        // Make JobOrganization optional if it should be
        public string JobOrganization { get; set; }

        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public string HRContact { get; set; }
        public string WorkingHours { get; set; }
        public decimal Salary { get; set; }
    }

}
