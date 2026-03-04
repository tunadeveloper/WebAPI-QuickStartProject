using AutoMapper;
using QuickStartProject.WebAPILayer.DTOs.AboutDTOs;
using QuickStartProject.WebAPILayer.DTOs.ContactDTOs;
using QuickStartProject.WebAPILayer.DTOs.FaqDTOs;
using QuickStartProject.WebAPILayer.DTOs.FeatureDTOs;
using QuickStartProject.WebAPILayer.DTOs.FeaturedServiceDTOs;
using QuickStartProject.WebAPILayer.DTOs.MessageDTOs;
using QuickStartProject.WebAPILayer.DTOs.NewsletterDTOs;
using QuickStartProject.WebAPILayer.DTOs.PricingDTOs;
using QuickStartProject.WebAPILayer.DTOs.ServiceDTOs;
using QuickStartProject.WebAPILayer.DTOs.TestimonialDTOs;
using QuickStartProject.WebAPILayer.Entities;

namespace QuickStartProject.WebAPILayer.AutoMapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Contact, ResultContactDTO>().ReverseMap();
            CreateMap<Contact, UpdateContactDTO>().ReverseMap();
            CreateMap<Contact, CreateContactDTO>().ReverseMap();

            CreateMap<FeaturedService, ResultFeaturedServiceDTO>().ReverseMap();
            CreateMap<FeaturedService, UpdateFeaturedServiceDTO>().ReverseMap();
            CreateMap<FeaturedService, CreateFeaturedServiceDTO>().ReverseMap();

            CreateMap<About, ResultAboutDTO>().ReverseMap();
            CreateMap<About, UpdateAboutDTO>().ReverseMap();
            CreateMap<About, CreateAboutDTO>().ReverseMap();

            CreateMap<Service, ResultServiceDTO>().ReverseMap();
            CreateMap<Service, UpdateServiceDTO>().ReverseMap();
            CreateMap<Service, CreateServiceDTO>().ReverseMap();

            CreateMap<Pricing, ResultPricingDTO>().ReverseMap();
            CreateMap<Pricing, UpdatePricingDTO>().ReverseMap();
            CreateMap<Pricing, CreatePricingDTO>().ReverseMap();

            CreateMap<Faq, ResultFaqDTO>().ReverseMap();
            CreateMap<Faq, UpdateFaqDTO>().ReverseMap();
            CreateMap<Faq, CreateFaqDTO>().ReverseMap();

            CreateMap<Feature, ResultFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();

            CreateMap<Testimonial, ResultTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, UpdateTestimonialDTO>().ReverseMap();
            CreateMap<Testimonial, CreateTestimonialDTO>().ReverseMap();

            CreateMap<Message, ResultMessageDTO>().ReverseMap();
            CreateMap<Message, UpdateMessageDTO>().ReverseMap();
            CreateMap<Message, CreateMessageDTO>().ReverseMap();

            CreateMap<Newsletter, ResultNewsletterDTO>().ReverseMap();
            CreateMap<Newsletter, UpdateNewsletterDTO>().ReverseMap();
            CreateMap<Newsletter, CreateNewsletterDTO>().ReverseMap();
        }
    }
}
