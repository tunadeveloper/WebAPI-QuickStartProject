using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickStartProject.WebAPILayer.DTOs.NewsletterDTOs;
using QuickStartProject.WebAPILayer.Entities;
using QuickStartProject.WebAPILayer.Repositories;

namespace QuickStartProject.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsletterController : ControllerBase
    {
        private readonly IRepositoryService<Newsletter> _service;
        private readonly IMapper _mapper;

        public NewsletterController(IRepositoryService<Newsletter> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetNewsletterList()
        {
            var values = await _service.GetAllAsync();
            var mapped = _mapper.Map<List<ResultNewsletterDTO>>(values);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewsletter(CreateNewsletterDTO dto)
        {
            var mapped = _mapper.Map<Newsletter>(dto);
            await _service.AddAsync(mapped);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNewsletter(UpdateNewsletterDTO dto)
        {
            var mapped = _mapper.Map<Newsletter>(dto);
            await _service.UpdateAsync(mapped);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNewsletter(int id)
        {
            var values = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(values);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdNewsletter(int id)
        {
            var value = await _service.GetByIdAsync(id);
            var mapped = _mapper.Map<ResultNewsletterDTO>(value);
            return Ok(mapped);
        }
    }
}
