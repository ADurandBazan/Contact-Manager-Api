using ContactManager.Domain.Entities;
using ContactManager.Infrastructure.Common.Models;
using ContactManager.Infrastructure.Common.Utilies;
using ContactManager.Infrastructure.Data;
using ContactManager.Infrastructure.DataAccess.FilterOptions;
using ContactManager.Infrastructure.DataAccess.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Infrastructure.DataAccess.Repositories
{
    /// <summary>
    /// A repository for the <see cref="Contact"/> entity.
    /// </summary>
    /// <seealso cref="Repository{Contact}" />
    /// <seealso cref="IContactRepository" />
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContactRepository"/> class.
        /// </summary>
        /// <param name="context">The context for the repository.</param>
        public ContactRepository(IUnitOfWork<ApplicationDbContext> context) : base(context)
        {
        }

        /// <summary>
        /// Finds all contacts.
        /// </summary>
        /// <param name="options">The filter options for the contacts.</param>
        /// <param name="pageNumber">The page number of the contacts.</param>
        /// <param name="pageSize">The page size of the contacts.</param>
        /// <returns>A paginated list of contacts.</returns>
        public async Task<PaginatedList<Contact>> FindAllContactsAsync(ContactFilterOptions? options = null, int pageNumber = 0, int pageSize = int.MaxValue)
        {
            IQueryable<Contact> query = Entity.AsQueryable();

            if (options is not null)
            {
                if (!string.IsNullOrEmpty(options.FirstName))
                {
                    query = query.Where(e => e.FirstName.ToLower().Contains(options.FirstName.ToLower()));
                }
                if (!string.IsNullOrEmpty(options.LastName))
                {
                    query = query.Where(e => e.LastName.ToLower().Contains(options.LastName.ToLower()));
                }
            }

            return await query.PaginatedListAsync(pageNumber, pageSize);
        }

        /// <summary>
        /// Gets a contact by email.
        /// </summary>
        /// <param name="email">The email of the contact.</param>
        /// <param name="cancellationToken">The cancellation token for the operation.</param>
        /// <returns>The contact with the specified email, or null if no such contact exists.</returns>
        public async Task<Contact?> GetContactByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            IQueryable<Contact> query = Entity.AsQueryable();
            return await query.FirstOrDefaultAsync(c => c.Email.Equals(email), cancellationToken);
        }
    }
}
