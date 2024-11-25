using RegistrationManagementAPI.Entities;

namespace RegistrationManagementAPI.Services.Interface
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetCoursesByTeacherIdAsync(int teacherId);
        Task<Course> AddCourseAsync(Course course);
        Task UpdateCourseAsync(int id, Course course);
        Task DeleteCourseAsync(int id);
    }
}
