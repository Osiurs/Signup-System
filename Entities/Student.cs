namespace RegistrationManagementAPI.Entities
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ParentName { get; set; }
        public string ParentPhoneNumber { get; set; }

        // Relationships
        public ICollection<Registration> Registrations { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}