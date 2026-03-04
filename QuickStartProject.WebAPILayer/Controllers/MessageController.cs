using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickStartProject.WebAPILayer.DTOs.MessageDTOs;
using QuickStartProject.WebAPILayer.Entities;
using QuickStartProject.WebAPILayer.Repositories;

namespace QuickStartProject.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IRepositoryService<Message> _service;
        private readonly IMapper _mapper;

        public MessageController(IRepositoryService<Message> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMessageList()
        {
            var values = await _service.GetAllAsync();
            var mapped = _mapper.Map<List<ResultMessageDTO>>(values);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(CreateMessageDTO dto)
        {
            var mapped = _mapper.Map<Message>(dto);
            await _service.AddAsync(mapped);
            return Ok("Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMessage(UpdateMessageDTO dto)
        {
            var mapped = _mapper.Map<Message>(dto);
            await _service.UpdateAsync(mapped);
            return Ok("Güncellendi");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessage(int id)
        {
            var values = await _service.GetByIdAsync(id);
            await _service.DeleteAsync(values);
            return Ok("Silindi");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdMessage(int id)
        {
            var value = await _service.GetByIdAsync(id);
            var mapped = _mapper.Map<ResultMessageDTO>(value);
            return Ok(mapped);
        }
    }
}
