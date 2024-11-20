using RegistrationManagementAPI.Entities;
namespace RegistrationManagementAPI.DTOs
{
    public class RegistrationDTO
    {
        public int RegistrationId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Status { get; set; } // "Pending", "Confirmed", "Canceled"
        public int StudentId { get; set; }

        public int CourseId { get; set; }
    }
}