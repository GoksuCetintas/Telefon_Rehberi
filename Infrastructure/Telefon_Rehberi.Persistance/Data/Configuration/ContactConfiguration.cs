using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telefon_Rehberi.Domain.Entities;

namespace Telefon_Rehberi.Persistance.Data.Configuration
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(x => x.FirstName).HasAnnotation("DisplayName", "Ad").HasMaxLength(100);
            builder.Property(x => x.LastName).HasAnnotation("DisplayName", "Soyad").HasMaxLength(100);
            builder.Property(x => x.Phone).HasAnnotation("DisplayName", "Telefon Numarası").HasMaxLength(50);
            builder.Property(x => x.Email).HasAnnotation("DisplayName", "E-posta Adresi").HasMaxLength(100);
        }
    }
}
