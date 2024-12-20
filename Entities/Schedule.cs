namespace RegistrationManagementAPI.Entities
{
    public class Schedule
    {
        public int ScheduleId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        
        // Relationships
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

         // Thêm StudentId nếu cần thiết
        public int? StudentId { get; set; } // nullable nếu không bắt buộc
        public Student Student { get; set; }

    }
}