using InsurancePolicyManagement.API.Domain.Entities;
using InsurancePolicyManagement.API.Domain.Interfaces;
using InsurancePolicyManagement.API.Infrastructure.Repositories;

namespace InsurancePolicyManagement.API.Domain.Services
{
    public class PolicyService : IPolicyService
    {
        private readonly IPolicyRepository _policyRepository;

        public PolicyService(IPolicyRepository policyRepository)
        {
            _policyRepository = policyRepository;
        }

        public async Task<IEnumerable<Policy>> GetAllAsync() => await _policyRepository.GetAllAsync();
        public async Task<Policy?> GetByIdAsync(int id) => await _policyRepository.GetByIdAsync(id);
        public async Task AddAsync(Policy policy)
        {
            policy.CreatedtDate = DateTime.Now;
            policy.CreatedBy = "System";
            await _policyRepository.AddAsync(policy);
        }
        public async Task UpdateAsync(Policy policy)
        {
            policy.UpdatedDate = DateTime.Now;
            policy.ModifiedBy = "System";
            await _policyRepository.UpdateAsync(policy);
        }
        public async Task DeleteAsync(int id) => await _policyRepository.DeleteAsync(id);
    }
}
