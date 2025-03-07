using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ElevateWorkforceSolutionsJP.Models
{
    public class JoblistViewModel : CommonViewModel
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
