using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_för_CV_hantering.Models
{
    public class Experience
    {
        [Key]
        public int ExperienceId { get; set; }


        [Required]
        [StringLength(50)]
        public string Company { get; set; }

        [Required]
        [StringLength(25)]
        public string JobTitle { get; set; }

        [StringLength(300)]
        public string Description { get; set; }


        [DataType(DataType.Date)]
        public DateOnly StartDate { get; set; }



        [DataType(DataType.Date)]
        public DateOnly? EndDate { get; set; }


        [ForeignKey("Person")]
        public int PersonId_FK { get; set; }
        public virtual Person Person { get; set; }
    }
}
