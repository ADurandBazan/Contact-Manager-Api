using ContactManager.Domain.Entities;

namespace ContactManager.Infrastructure.Common.Interfaces
{
    /// <summary>
    /// An interface for handler users.
    /// </summary>
    public interface IUserHelper
    {
        /// <summary>
        /// Gets a user by username asynchronously.
        /// </summary>
        /// <param name="username">The username of the user to get.</param>
        /// <returns>A task that represents the asynchronous get operation.</returns>
        Task<User> GetUserByUsername(string username);
    }
}