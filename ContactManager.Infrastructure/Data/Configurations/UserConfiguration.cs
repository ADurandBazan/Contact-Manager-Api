using ContactManager.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.Data.Configurations
{
    /// <summary>
    /// A configuration class for the <see cref="User"/> entity.
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.FirstName)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(t => t.LastName)
                .HasMaxLength(128)
                .IsRequired();

            builder.Property(t => t.UserName)
                .HasMaxLength(60)
                .IsRequired();

            builder.Property(t => t.Password)
                .HasMaxLength(256)
                .IsRequired();
        }
    }
}