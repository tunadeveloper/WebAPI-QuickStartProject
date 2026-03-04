using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickStartProject.WebAPILayer.DTOs.ContactDTOs;
using QuickStartProject.WebAPILayer.Entities;
using QuickStartProject.WebAPILayer.Repositories;
using System.Threading.Tasks;

namespace QuickStartProject.WebAPILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IRepositoryService<Contact> _service;
        private readonly IMapper _mapper;

        public ContactController(IRepositoryService<Contact> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetContactList()
        {
            var values = await _service.GetAllAsync();
            var mapped = _mapper.Map<List<ResultContactDTO>>(values);
            return Ok(mapped);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDTO dto)
        {
            var mapped = _mapper.Map<Contact>(dto);
            await _service.AddAsync(mapped);
            return Ok("Eklendi");
        }
    }
}
