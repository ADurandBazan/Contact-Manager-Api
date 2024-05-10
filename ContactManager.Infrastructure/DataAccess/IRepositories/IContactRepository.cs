using ContactManager.Domain.Entities;
using ContactManager.Infrastructure.Common.Interfaces;
using ContactManager.Infrastructure.Common.Models;
using ContactManager.Infrastructure.DataAccess.FilterOptions;

namespace ContactManager.Infrastructure.DataAccess.IRepositories
{
    // <summary>
    /// A repository interface for the <see cref="Contact"/> entity.
    /// </summary>
    public interface IContactRepository : IRepository<Contact>
    {
        /// <summary>
        /// Finds all contacts.
        /// </summary>
        /// <param name="options">The filter options for the contacts.</param>
        /// <param name="pageNumber">The page number of the contacts.</param>
        /// <param name="pageSize">The page size of the contacts.</param>
        /// <returns>A paginated list of contacts.</returns>
        Task<PaginatedList<Contact>> FindAllContactsAsync(ContactFilterOptions? options = null, int pageNumber = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// Gets a contact by email.
        /// </summary>
        /// <param name="email">The email of the contact.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The contact with the specified email, or null if no such contact exists.</returns>
        Task<Contact?> GetContactByEmailAsync(string email, CancellationToken cancellationToken = default);
    }
}
