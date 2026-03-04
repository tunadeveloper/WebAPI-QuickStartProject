using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickStartProject.WebAPILayer.DTOs.FeaturedServiceDTOs;
using QuickStartProject.WebAPILayer.Entities;
using QuickStartProject.WebAPILayer.Repositories;

namespace QuickStartProject.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturedServiceController : ControllerBase
    {
        private readonly IRepositoryService<FeaturedService> _service;
        private readonly IMapper _mapper;

        public FeaturedServiceController(IRepositoryService<FeaturedService> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeaturedServiceList()
        {
            var values = await _service.GetAllAsync();
            var mapped = _mapper.Map<List<ResultFeaturedServiceDTO>>(values);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeaturedService(CreateFeaturedServiceDTO dto)
        {
            var mapped = _mapper.Map<FeaturedService>(dto);
            await _service.AddAsync(mapped);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeaturedService(UpdateFeaturedServiceDTO dto)
        {
            var mapped = _mapper.Map<FeaturedService>(dto);
            await _service.UpdateAsync(mapped);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeaturedService(int id)
        {
            var values = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(values);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeaturedService(int id)
        {
            var value = await _service.GetByIdAsync(id);
            var mapped = _mapper.Map<ResultFeaturedServiceDTO>(value);
            return Ok(mapped);
        }
    }
}
