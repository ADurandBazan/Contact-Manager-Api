using AutoMapper;
using ContactManager.Application.ApplicationServices.IServices;
using ContactManager.Application.ApplicationServices.Maps;
using ContactManager.Application.Common.Exceptions;
using ContactManager.Application.Common.Interfaces;
using ContactManager.Domain.Entities;
using ContactManager.Infrastructure.Common.Interfaces;
using ContactManager.Infrastructure.DataAccess.FilterOptions;
using ContactManager.Infrastructure.DataAccess.IRepositories;

namespace ContactManager.Application.ApplicationServices.Services
{
    public class ContactService : IContactService
    {

        #region Fields
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly IUser _user;
        private readonly IUserHelper _userHelper;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the ContactService class
        /// </summary>
        /// <param name="contactRepository">Repository for accessing contact data</param>
        /// <param name="mapper">Mapper for converting between entity and DTO objects</param>
        /// <param name="user">Interface for accessing to current user information</param>
        /// <param name="userHelper">Interface for accessing to current user information form database</param>
        public ContactService(IContactRepository contactRepository, 
                              IMapper mapper, 
                              IUser user,
                              IUserHelper userHelper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _user = user;
            _userHelper = userHelper;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Creates a new contact asynchronously
        /// </summary>
        /// <param name="contactDto">Contact data to be created</param>
        /// <param name="cancellationToken">Cancellation token for the operation (optional)</param>
        /// <returns>A task that represents the asynchronous operation, containing the created contact Dto</returns>
        public async Task<ContactDto> CreateAsync(ContactDto contactDto, CancellationToken cancellationToken = default)
        {
            var contact = _mapper.Map<Contact>(contactDto);

            //getting current user and setting in contact as owner
            contact.Owner = await _userHelper.GetUserByUsername(_user.Username!);
            
            await _contactRepository.SaveAsync(contact);

            return _mapper.Map<ContactDto>(contact);
        }

        /// <summary>
        /// Deletes a contact asynchronously
        /// </summary>
        /// <param name="contactId">ID of the contact to be deleted</param>
        /// <param name="cancellationToken">Cancellation token for the operation (optional)</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public async Task DeleteAsync<TId>(TId contactId, CancellationToken cancellationToken = default)
        {
            var contact = await GetContactByIdAsync(contactId, cancellationToken);
            await _contactRepository.DeleteAsync(contact);
           
        }

        /// <summary>
        /// Finds all contacts asynchronously based on the provided filter options and pagination settings
        /// </summary>
        /// <param name="filterOptions">Optional filter options to apply to the search</param>
        /// <param name="pageNumber">Optional page number to retrieve (defaults to 1)</param>
        /// <param name="pageSize">Optional page size to retrieve (defaults to int.MaxValue)</param>
        /// <returns>A task that represents the asynchronous operation, containing a list of contact DTOs</returns>
        public async Task<IEnumerable<ContactDto>> FindAllContactsAsync(ContactFilterOptions? filterOptions = null, int pageNumber = 1, int pageSize = int.MaxValue)
        {
            var contacts = await _contactRepository.FindAllContactsAsync(filterOptions, pageNumber, pageSize);
            return _mapper.Map<List<ContactDto>>(contacts.Items.ToList());
        }

        /// <summary>
        /// Retrieves a contact by ID asynchronously
        /// </summary>
        /// <param name="contactId">ID of the contact to be retrieved</param>
        /// <param name="cancellationToken">Cancellation token for the operation (optional)</param>
        /// <returns>A task that represents the asynchronous operation, containing the retrieved contact DTO</returns>
        public async Task<ContactDto> GetByIdAsync<TId>(TId contactId, CancellationToken cancellationToken = default)
        {
            var contact = await GetContactByIdAsync(contactId, cancellationToken);

            return _mapper.Map<ContactDto>(contact);
        }

        /// <summary>
        /// Updates a contact asynchronously
        /// </summary>
        /// <typeparam name="T">Type of the contact ID</typeparam>
        /// <param name="id">ID of the contact to be updated</param>
        /// <param name="contactDto">Updated contact data</param>
        /// <param name="cancellationToken">Cancellation token for the operation (optional)</param>
        /// <returns>A task that represents the asynchronous operation, containing the updated contact DTO</returns>
        public async Task UpdateAsync<T>(T id, ContactDto contactDto, CancellationToken cancellationToken = default)
        {
            var contact = await GetContactByIdAsync(id, cancellationToken);

            _mapper.Map(contactDto, contact);
                await _contactRepository.UpdateAsync(contact, cancellationToken);
               
        }

        /// <summary>
        /// Retrieves a contact by ID asynchronously
        /// </summary>
        /// <param name="id">ID of the contact to be retrieved</param>
        /// <param name="cancellationToken">Cancellation token for the operation (optional)</param>
        /// <returns>A task that represents the asynchronous operation, containing the retrieved contact entity</returns>
        private async Task<Contact> GetContactByIdAsync<TId>(TId id, CancellationToken cancellationToken = default) 
        {
            var contact = await _contactRepository.GetByIdAsync(id, cancellationToken);

            if (contact is null)
                throw new ElementNotFoundException($"Contact with Id = {id} not found");
            
            return contact;
        }
        #endregion
    }
}