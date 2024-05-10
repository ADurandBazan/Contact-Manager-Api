using ContactManager.Application.ApplicationServices.IServices;
using ContactManager.Application.ApplicationServices.Maps;
using ContactManager.Application.ApplicationServices.Validators;
using ContactManager.Application.Common.Exceptions;
using ContactManager.Infrastructure.DataAccess.FilterOptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManager.Api.Controllers
{
    /// <summary>
    /// ContactController class for handling contact-related requests
    /// </summary>
    [ApiController]
    [Authorize]
    [Route("api/contacts")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ContactDtoValidator _validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactController"/> class
        /// </summary>
        /// <param name="contactService">The contact service for handling contact-related operations</param>
        /// <param name="validator">The validator for validating contact DTOs</param>
        public ContactController(IContactService contactService, ContactDtoValidator validator)
        {
            _contactService = contactService;
            _validator = validator;
        }

        /// <summary>
        /// Gets all contacts with optional filtering and pagination
        /// </summary>
        /// <param name="request">The filtering options for the contacts</param>
        /// <param name="pageNumber">The page number to retrieve</param>
        /// <param name="pageSize">The number of contacts to retrieve per page</param>
        /// <returns>A list of contacts with pagination information</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] ContactFilterOptions? request = null, int pageNumber = 1, int pageSize = int.MaxValue)
        {
            var contacts = await _contactService.FindAllContactsAsync(request, pageNumber, pageSize);

            return Ok(new
            {
                success = true,
                data = contacts
            });
        }

        /// <summary>
        /// Gets a contact by ID.
        /// </summary>
        /// <param name="id">The ID of the contact.</param>
        /// <returns>The contact with the specified ID, or a 404 Not Found response if no such contact exists.</returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
           try
           {
                var contact = await _contactService.GetByIdAsync(id);
                return Ok(new
                {
                    success = true,
                    data = contact
                });
           }
           catch (ElementNotFoundException ex)
           {
                return NotFound(new { success = false, message = ex.Message });
           }
        }

        /// <summary>
        /// Creates a new contact
        /// </summary>
        /// <param name="contactDto">The contact DTO to create</param>
        /// <returns>The created contact</returns>
        /// <response code="201">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="500">Internal server error</response>
        [HttpPost]
        public async Task<IActionResult> CreateContact(ContactDto contactDto)
        {
            var result = await _validator.ValidateAsync(contactDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            var contact = await _contactService.CreateAsync(contactDto);
            if (contact != null)
            {
                // Construct the URL for the newly created resource
                var newResourceUrl = Url.Action("GetById", new { id = contact.Id });

                // Return a 201 Created response with the Location header
                return CreatedAtAction("GetById", new { id = contact.Id }, contact);
            }

            return StatusCode(500);

        }

        /// <summary>
        /// Updates an existing contact
        /// </summary>
        /// <param name="id">The ID of the contact to update</param>
        /// <param name="contactDto">The updated contact DTO</param>
        /// <returns>The updated contact</returns>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal error</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id, ContactDto contactDto)
        {
            var result = await _validator.ValidateAsync(contactDto);

            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }

            try
            {
                await _contactService.UpdateAsync(id, contactDto);
                return Ok(new { success = true });
            }
            catch (ElementNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }


        }

        /// <summary>
        /// Deletes a contact
        /// </summary>
        /// <param name="id">The ID of the contact to delete</param>
        /// <returns>A message indicating success</returns>
        /// <response code="200">Success</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Internal error</response>
        [HttpDelete("{id}")]
        [Authorize(Policy = "DeleteContactPolicy")]
        public async Task<IActionResult> DeleteContact(Guid id)
        {
            try
            {
                await _contactService.DeleteAsync(id);
                return Ok(new { success = true});
            }
            catch (ElementNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}
