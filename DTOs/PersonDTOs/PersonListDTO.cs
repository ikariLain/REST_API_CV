using REST_API_för_CV_hantering.DTOs.EducationDTOs;

namespace REST_API_för_CV_hantering.DTOs.PersonDTOs
{
    public class PersonListDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Description { get; set; }
        public List<EducationDTO> Educations { get; set; }
        public List<ExperienceDTO> Experiences { get; set; }
    }
}
