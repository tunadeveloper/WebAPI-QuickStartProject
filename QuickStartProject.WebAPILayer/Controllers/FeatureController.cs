using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickStartProject.WebAPILayer.DTOs.FeatureDTOs;
using QuickStartProject.WebAPILayer.Entities;
using QuickStartProject.WebAPILayer.Repositories;

namespace QuickStartProject.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IRepositoryService<Feature> _service;
        private readonly IMapper _mapper;

        public FeatureController(IRepositoryService<Feature> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFeatureList()
        {
            var values = await _service.GetAllAsync();
            var mapped = _mapper.Map<List<ResultFeatureDTO>>(values);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDTO dto)
        {
            var mapped = _mapper.Map<Feature>(dto);
            await _service.AddAsync(mapped);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDTO dto)
        {
            var mapped = _mapper.Map<Feature>(dto);
            await _service.UpdateAsync(mapped);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFeature(int id)
        {
            var values = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(values);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdFeature(int id)
        {
            var value = await _service.GetByIdAsync(id);
            var mapped = _mapper.Map<ResultFeatureDTO>(value);
            return Ok(mapped);
        }
    }
}
