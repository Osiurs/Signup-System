using RegistrationManagementAPI.Entities;

namespace RegistrationManagementAPI.Services.Interface
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetAllPaymentsAsync();
        Task<IEnumerable<Payment>> GetPaymentsByStudentIdAsync(int studentId);
        Task<IEnumerable<Payment>> GetPaymentsByRegistrationIdAsync(int registrationId);
        Task<Payment> GetPaymentByIdAsync(int id);
        Task<Payment> AddPaymentAsync(Payment payment);
        Task UpdatePaymentAsync(int id, Payment payment);
        Task DeletePaymentAsync(int id);
    }
}
