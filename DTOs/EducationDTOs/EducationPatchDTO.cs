using System.ComponentModel.DataAnnotations;

namespace REST_API_för_CV_hantering.DTOs.EducationDTOs
{
    public class EducationPatchDTO
    {
        [StringLength(50, ErrorMessage = "School name cannot exceed 50 characters.")]
        public string? School { get; set; }

        [StringLength(50, ErrorMessage = "Degree cannot exceed 50 characters.")]
        public string? Degree { get; set; }


        [DataType(DataType.Date, ErrorMessage = "Start date must be a valid date.")]
        public DateOnly? StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "End date must be a valid date.")]
        public DateOnly? EndDate { get; set; }

        public int? PersonId_FK { get; set; }
    }
}
