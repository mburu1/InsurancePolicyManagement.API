using InsurancePolicyManagement.API.Domain.Entities;
using InsurancePolicyManagement.API.Domain.Interfaces;
using InsurancePolicyManagement.API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InsurancePolicyManagement.API.Infrastructure.Repositories
{
    public class PolicyRepository : IPolicyRepository
    {
        private readonly InsuranceDbContext _context;

        public PolicyRepository(InsuranceDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Policy>> GetAllAsync()
        {
            return await _context.Policies.ToListAsync();
        }

        public async Task<Policy?> GetByIdAsync(int id)
        {
            return await _context.Policies.FindAsync(id);
        }

        public async Task AddAsync(Policy policy)
        {
            await _context.Policies.AddAsync(policy);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Policy policy)
        {
            _context.Policies.Update(policy);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var policy = await _context.Policies.FindAsync(id);
            if (policy != null)
            {
                _context.Policies.Remove(policy);
                await _context.SaveChangesAsync();
            }
        }
    }
}
