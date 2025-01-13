using InsurancePolicyManagement.API.Domain.Entities;
using InsurancePolicyManagement.API.Domain.Interfaces;
using InsurancePolicyManagement.API.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace InsurancePolicyManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PolicyController : ControllerBase
    {
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService)
        {
            _policyService = policyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var policies = await _policyService.GetAllAsync();
            return Ok(policies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var policy = await _policyService.GetByIdAsync(id);
            return policy == null ? NotFound() : Ok(policy);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Policy policy)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            await _policyService.AddAsync(policy);
            return CreatedAtAction(nameof(GetById), new { id = policy.Id }, policy);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Policy policy)
        {
            if (id != policy.Id) return BadRequest();
            await _policyService.UpdateAsync(policy);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _policyService.DeleteAsync(id);
            return NoContent();
        }
    }
}
