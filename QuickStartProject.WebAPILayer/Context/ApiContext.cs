using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickStartProject.WebAPILayer.Entities;

namespace QuickStartProject.WebAPILayer.Context
{
    public class ApiContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public DbSet<FeaturedService> FeaturedServices { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
    }
}
