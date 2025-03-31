using System.ComponentModel.DataAnnotations;

namespace REST_API_för_CV_hantering.DTOs.ExperienceDTOs
{
    public class ExperienceDTO
    {
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Description { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
