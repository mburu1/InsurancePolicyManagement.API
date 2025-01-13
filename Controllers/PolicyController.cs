using Azure.Core;
using InsurancePolicyManagement.API.Domain.Entities;
using InsurancePolicyManagement.API.Domain.Interfaces;
using InsurancePolicyManagement.API.Domain.Services;
using InsurancePolicyManagement.API.DTOs;
using Microsoft.AspNetCore.Mvc;
using Mapster;

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
        public async Task<IActionResult> Create(PolicyDTO policy)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var _policy = policy.Adapt<Policy>();
            await _policyService.AddAsync(_policy);
            return CreatedAtAction(nameof(Create), new { PolicyNumber = policy.PolicyNumber }, policy);
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
