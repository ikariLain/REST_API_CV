using System.ComponentModel.DataAnnotations;

namespace REST_API_för_CV_hantering.DTOs.PersonDTOs
{
    public class PersonCreateDTO
    {
        [Required, StringLength(50, MinimumLength =5)]
        public string Name { get; set; }

        [Required, EmailAddress, StringLength(50, MinimumLength =5)]
        public string Email { get; set; }

        [Required,Phone, StringLength (50, MinimumLength = 5)]
        public string MobileNumber { get; set; }

        [Required, StringLength (400, MinimumLength = 5)]
        public string Description { get; set; }

    }
}
