using System.ComponentModel.DataAnnotations;

namespace REST_API_för_CV_hantering.DTOs.EducationDTOs
{
    public class EducationCreateDTO
    {
        [Required (ErrorMessage ="Missing school name.")]

        [StringLength (50, ErrorMessage = "School name can't contain more than 50 characters")]
        public string School {  get; set; }

        [Required (ErrorMessage = "Missing degree name")]

        [StringLength(50, ErrorMessage = "degree name can't contain more than 50 characters")]
        public  string Degree { get; set; }

        [Required(ErrorMessage = "Missing date.")]

        [DataType (DataType.Date, ErrorMessage = "Need a valid date.")]
        public DateOnly StartDate { get; set; }


        [Required(ErrorMessage = "Missing Enddate.")]

        [DataType(DataType.Date, ErrorMessage = "Need a valid date.")]
        public DateOnly EndDate { get; set; }

    }
}
