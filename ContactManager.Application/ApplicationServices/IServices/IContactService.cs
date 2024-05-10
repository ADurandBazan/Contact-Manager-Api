using ContactManager.Application.ApplicationServices.Maps;
using ContactManager.Application.Common.Interfaces;
using ContactManager.Infrastructure.Common.Models;
using ContactManager.Infrastructure.DataAccess.FilterOptions;

namespace ContactManager.Application.ApplicationServices.IServices
{
    public interface IContactService : ICrudService<ContactDto>
    {
        Task<IEnumerable<ContactDto>> FindAllContactsAsync(ContactFilterOptions? filterOptions = null, int pageNumber = 1, int pageSize = int.MaxValue);
    }
}
