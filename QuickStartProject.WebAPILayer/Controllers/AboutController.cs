using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuickStartProject.WebAPILayer.DTOs.AboutDTOs;
using QuickStartProject.WebAPILayer.Entities;
using QuickStartProject.WebAPILayer.Repositories;

namespace QuickStartProject.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IRepositoryService<About> _service;
        private readonly IMapper _mapper;

        public AboutController(IRepositoryService<About> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAboutList()
        {
            var values = await _service.GetAllAsync();
            var mapped = _mapper.Map<List<ResultAboutDTO>>(values);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDTO dto)
        {
            var mapped = _mapper.Map<About>(dto);
            await _service.AddAsync(mapped);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDTO dto)
        {
            var mapped = _mapper.Map<About>(dto);
            await _service.UpdateAsync(mapped);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var values = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(values);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAbout(int id)
        {
            var value = await _service.GetByIdAsync(id);
            var mapped = _mapper.Map<ResultAboutDTO>(value);
            return Ok(mapped);
        }
    }
}
