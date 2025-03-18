using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_för_CV_hantering.Models
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }


        [Required]
        [StringLength(25)]
        public string FirstName { get; set; }


        [Required]
        [StringLength(25)]
        public string LastName { get; set; }


        [Required]
        [StringLength(25)]
        public string Email { get; set; }

        [Required]
        [StringLength(25)]
        public string MobileNumber { get; set; }

        
        List<Education> Educations { get; set; }

        List<Experience> Experiences { get; set; }



    }
}
