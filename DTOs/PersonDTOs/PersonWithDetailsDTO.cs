using REST_API_för_CV_hantering.DTOs.EducationDTOs;
using REST_API_för_CV_hantering.DTOs.ExperienceDTOs;


namespace REST_API_för_CV_hantering.DTOs.PersonDTOs
{
    public class PersonWithDetailsDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string Description { get; set; }
        public List<EducationDTO> Educations { get; set; }
        public List<ExperienceDTO> Experiences { get; set; }
    }
}
