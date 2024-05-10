using ContactManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ContactManager.Infrastructure.Data
{
    /// <summary>
    /// A class for initializing and seeding the database.
    /// </summary>
    public class ApplicationDbContextInitialiser
    {
        private readonly ILogger<ApplicationDbContextInitialiser> _logger;
        private readonly ApplicationDbContext _context;
      
        public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        /// <summary>
        /// Initializes the database and run pending migrations.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task InitialiseAsync()
        {
            try
            {
                await _context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while initialising the database.");
                throw;
            }
        }

        // <summary>
        /// Seeds the database with default data.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task SeedAsync()
        {
            try
            {
                await TrySeedAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the database.");
                throw;
            }
        }

        /// <summary>
        /// Seeds the database with default data, if necessary.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task TrySeedAsync()
        {
            if (!_context.Users.Any())
            {
                _context.Users.Add(new User
                {
                    FirstName = "Jhonny",
                    LastName = "Rocket",
                    UserName = "jrocket@example.com",
                    Password = "240be518fabd2724ddb6f04eeb1da5967448d7e831c08c8fa822809f74c720a9"
                });
             
                await _context.SaveChangesAsync();
            }
        }
    }
}
