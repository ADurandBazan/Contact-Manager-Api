using ContactManager.Domain.Entities;
using ContactManager.Infrastructure.Common.Interfaces;
using ContactManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure.Common.Utilies
{
    /// <summary>
    /// A helper class for working with users.
    /// </summary>
    public class UserHelper : IUserHelper
    {
        /// <summary>
        /// The context for working with users.
        /// </summary>
        private readonly DbSet<User> _usersContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserHelper"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public UserHelper(ApplicationDbContext dbContext)
        {
            _usersContext = dbContext.Users;
        }

        /// <summary>
        /// Gets a user by username.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <returns>The user with the specified username.</returns>
        public async Task<User> GetUserByUsername(string username)
        {
            return await _usersContext.FirstAsync(u => u.UserName.Equals(username));
        }
    }
}
