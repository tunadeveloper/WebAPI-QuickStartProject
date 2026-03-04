using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickStartProject.WebAPILayer.DTOs.TestimonialDTOs;
using QuickStartProject.WebAPILayer.Entities;
using QuickStartProject.WebAPILayer.Repositories;

namespace QuickStartProject.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly IRepositoryService<Testimonial> _service;
        private readonly IMapper _mapper;

        public TestimonialController(IRepositoryService<Testimonial> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestimonialList()
        {
            var values = await _service.GetAllAsync();
            var mapped = _mapper.Map<List<ResultTestimonialDTO>>(values);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialDTO dto)
        {
            var mapped = _mapper.Map<Testimonial>(dto);
            await _service.AddAsync(mapped);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDTO dto)
        {
            var mapped = _mapper.Map<Testimonial>(dto);
            await _service.UpdateAsync(mapped);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            var values = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(values);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdTestimonial(int id)
        {
            var value = await _service.GetByIdAsync(id);
            var mapped = _mapper.Map<ResultTestimonialDTO>(value);
            return Ok(mapped);
        }
    }
}
