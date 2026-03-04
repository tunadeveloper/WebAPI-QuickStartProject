using AutoMapper;
using QuickStartProject.WebAPILayer.DTOs.ContactDTOs;
using QuickStartProject.WebAPILayer.Entities;

namespace QuickStartProject.WebAPILayer.AutoMapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
            CreateMap<Contact, CreateContactDTO>().ReverseMap();
        }
    }
}
