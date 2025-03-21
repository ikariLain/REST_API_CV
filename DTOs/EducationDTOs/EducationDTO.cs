namespace REST_API_för_CV_hantering.DTOs.EducationDTOs
{
    public class EducationDTO
    {
        public string School { get; set; }
        public string Degree { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
    }
}
