using System.ComponentModel.DataAnnotations;

namespace REST_API_för_CV_hantering.DTOs.ExperienceDTO
{
    public class PersonCreateDTO
    {
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Decription { get; set; }
        public int StartDate { get; set; }
        public int? EndDate { get; set; }
    }
}
