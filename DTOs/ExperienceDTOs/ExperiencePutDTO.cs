using System.ComponentModel.DataAnnotations;

namespace REST_API_för_CV_hantering.DTOs.ExperienceDTOs
{
    public class ExperiencePutDTO
    {
        [Required(ErrorMessage = "Person Id is required.")]
        public int PersonId { get; set; }

        [Required(ErrorMessage = "Company is required.")]
        [StringLength(50, ErrorMessage = "Company name cannot exceed 50 characters.")]
        public string Company { get; set; }

        [Required(ErrorMessage = "Job Title is required.")]
        [StringLength(50, ErrorMessage = "Job Title cannot exceed 50 characters.")]
        public string JobTitle { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(300, ErrorMessage = "Description cannot exceed 300 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "Start Date must be a valid date.")]
        public DateOnly StartDate { get; set; }

        [DataType(DataType.Date, ErrorMessage = "End Date must be a valid date.")]
        public DateOnly? EndDate { get; set; }
    }
}
