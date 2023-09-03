using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telefon_Rehberi.Domain.Entities;
using Telefon_Rehberi.Persistance.Data.Configuration;

namespace Telefon_Rehberi.Persistance.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { 
        }

        public DbSet<Contact> Contacts => Set<Contact>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ContactConfiguration).Assembly);
            builder.Entity<Contact>().HasData(new Contact()
            {
                Id = "417b8151-ff69-4511-b91e-fe8d114c47a0",
                FirstName = "Göksu",
                LastName = "Çetintaş",
                Phone = "05323248334",
                Email = "goksu.cetintas@arksoft.com",
            });
            base.OnModelCreating(builder);
        }
    }
}
