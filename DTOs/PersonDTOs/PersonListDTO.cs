using REST_API_för_CV_hantering.DTOs.EducationDTOs;
using REST_API_för_CV_hantering.DTOs.ExperienceDTOs;

namespace REST_API_för_CV_hantering.DTOs.PersonDTOs
{
    public class PersonListDTO
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
        public string Description { get; set; }
        public List<EducationDTO> Educations { get; set; }
        public List<ExperienceDTO> Experiences { get; set; }
    }
}
