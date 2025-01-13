using InsurancePolicyManagement.API.Domain.Entities;
using InsurancePolicyManagement.API.Infrastructure.Repositories;

namespace InsurancePolicyManagement.API.Domain.Interfaces
{
    public interface IPolicyService
    {
        public Task<IEnumerable<Policy>> GetAllAsync();
        public  Task<Policy?> GetByIdAsync(int id);
        public  Task AddAsync(Policy policy);
        public  Task UpdateAsync(Policy policy);
        public Task DeleteAsync(int id);
    }
}
