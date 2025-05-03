using System.ComponentModel.DataAnnotations;

namespace REST_API_för_CV_hantering.DTOs.PersonDTOs
{
    public class PersonCreateDTO
    {
        [Required(ErrorMessage = "Person Id is required.")]
        public int PersonId { get; set; }

        [Required (ErrorMessage = "Missing Firstname, its required"), StringLength(50, MinimumLength =5)]
        public string FirstName { get; set; }

        [Required (ErrorMessage = "Missing Lastname, its required "), StringLength(50, MinimumLength = 5)]
        public string LastName { get; set; }

        [Required (ErrorMessage = "Missing Email, its required"), EmailAddress, StringLength(50, MinimumLength =5)]
        public string Email { get; set; }

        [Required,Phone, StringLength (50, MinimumLength = 5)]
        public string MobileNumber { get; set; }

        [Required, StringLength (400, MinimumLength = 5)]
        public string Description { get; set; }

    }
}
