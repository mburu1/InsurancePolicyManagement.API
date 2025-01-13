using InsurancePolicyManagement.API.Domain.Entities;

namespace InsurancePolicyManagement.API.Domain.Interfaces
{
    public interface IPolicyRepository
    {
        Task<IEnumerable<Policy>> GetAllAsync();
        Task<Policy?> GetByIdAsync(int id);
        Task AddAsync(Policy policy);
        Task UpdateAsync(Policy policy);
        Task DeleteAsync(int id);
    }
}
