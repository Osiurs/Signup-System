using RegistrationManagementAPI.Entities;

namespace RegistrationManagementAPI.Services.Interface
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Registration>> GetAllRegistrationsAsync();
        Task<Registration> GetRegistrationByIdAsync(int id);
        Task<IEnumerable<Registration>> GetRegistrationsByStudentIdAsync(int studentId);
        Task<IEnumerable<Registration>> GetRegistrationsByCourseIdAsync(int courseId);
        Task<Registration> AddRegistrationAsync(Registration registration);
        Task UpdateRegistrationAsync(int id, Registration registration);
        Task DeleteRegistrationAsync(int id);
    }
}