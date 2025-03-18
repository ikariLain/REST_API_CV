using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REST_API_för_CV_hantering.Models
{
    public class Education
    {
        [Key]
        public int EducationId { get; set; }


        [Required]
        [StringLength(25)]
        public string School { get; set; }


        [Required]
        [StringLength(25)]
        public string Degree { get; set; }


        [DataType(DataType.Date)]
        public string StartDate { get; set; }


        [DataType(DataType.Date)]
        public string EndDate { get; set; }


        [ForeignKey("Person")]
        public int PersonId_FK { get; set; }
        public virtual Person Person { get; set; }

    }
}
