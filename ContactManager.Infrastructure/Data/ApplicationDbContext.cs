using ContactManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /// <summary>
        /// Configures the database model
        /// </summary>
        /// <param name="builder">Database model builder</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        /// <summary>
        /// DbSet for the Users entity
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// DbSet for the Contacts entity
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }
    }
}
