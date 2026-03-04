using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickStartProject.WebAPILayer.DTOs.PricingDTOs;
using QuickStartProject.WebAPILayer.Entities;
using QuickStartProject.WebAPILayer.Repositories;

namespace QuickStartProject.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingController : ControllerBase
    {
        private readonly IRepositoryService<Pricing> _service;
        private readonly IMapper _mapper;

        public PricingController(IRepositoryService<Pricing> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetPricingList()
        {
            var values = await _service.GetAllAsync();
            var mapped = _mapper.Map<List<ResultPricingDTO>>(values);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePricing(CreatePricingDTO dto)
        {
            var mapped = _mapper.Map<Pricing>(dto);
            await _service.AddAsync(mapped);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingDTO dto)
        {
            var mapped = _mapper.Map<Pricing>(dto);
            await _service.UpdateAsync(mapped);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePricing(int id)
        {
            var values = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(values);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdPricing(int id)
        {
            var value = await _service.GetByIdAsync(id);
            var mapped = _mapper.Map<ResultPricingDTO>(value);
            return Ok(mapped);
        }
    }
}
