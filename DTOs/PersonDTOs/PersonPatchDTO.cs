using System.ComponentModel.DataAnnotations;

namespace REST_API_för_CV_hantering.DTOs.PersonDTOs
{
    public class PersonPatchDTO
    {
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Full Name must be between 5 and 50 characters.")]
        public string? FirstName { get; set; }

        [StringLength(50, MinimumLength = 5, ErrorMessage = "Full Name must be between 5 and 50 characters.")]
        public string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Email Address must be between 5 and 50 characters.")]
        public string? EmailAddress { get; set; }

        [Phone(ErrorMessage = "Invalid MobileNumber format.")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "MobileNumber must be between 5 and 50 characters.")]
        public string? MobileNumber { get; set; }

        [StringLength(300, MinimumLength = 5, ErrorMessage = "Description must be between 5 and 300 characters.")]
        public string? Description { get; set; }
    }
}
