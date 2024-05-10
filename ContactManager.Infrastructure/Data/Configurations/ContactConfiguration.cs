using ContactManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManager.Infrastructure.Data.Configurations
{
    /// <summary>
    /// A configuration class for the <see cref="Contact"/> entity.
    /// </summary>
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(128);

            builder.Property(t => t.Email)
                .HasMaxLength(128);
               
            builder.HasIndex(t => t.Email)
                .IsUnique();

            builder.Property(t => t.Phone)
                .HasMaxLength(20)
                .IsRequired();

            builder.Property(c => c.DateOfBirth)
                .HasColumnType("datetime2");

           

        }
    }
}