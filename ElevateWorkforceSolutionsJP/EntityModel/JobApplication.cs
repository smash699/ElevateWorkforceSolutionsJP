using System.ComponentModel.DataAnnotations;

namespace ElevateWorkforceSolutionsJP.EntityModel
{
    public class JobApplication:Common
    {
        [Key]
        public int ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string AcademicQualification { get; set; }
        public string JobTitle { get; set; }
        public string OrganizationName { get; set; }

    }
}
