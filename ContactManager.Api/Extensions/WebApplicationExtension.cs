using ContactManager.Infrastructure.Data;

namespace ContactManager.Api.Extensions
{
    public static class WebApplicationExtension
    {
        /// <summary>
        /// Initialises the database asynchronously
        /// </summary>
        /// <param name="app">WebApplication instance</param>
        /// <returns>Task representing the asynchronous operation</returns>
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var initialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

            await initialiser.InitialiseAsync();

            await initialiser.SeedAsync();
        }
    }
}
