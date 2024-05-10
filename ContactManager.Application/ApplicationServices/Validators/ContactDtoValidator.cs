using ContactManager.Application.ApplicationServices.Maps;
using ContactManager.Application.Common.Utilities;
using ContactManager.Infrastructure.DataAccess.IRepositories;
using FluentValidation;
using FluentValidation.Validators;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.ApplicationServices.Validators
{
    // <summary>
    /// A validator class for the ContactDto class.
    /// </summary>
    public class ContactDtoValidator : AbstractValidator<ContactDto>
    {
        private readonly IContactRepository _contactRepository;

        public ContactDtoValidator(IContactRepository contactRepository)
        {

            _contactRepository = contactRepository;

            RuleFor(p => p.FirstName)
                .NotEmpty()
                .WithMessage(m => "First name is required")
                .MaximumLength(128)
                .WithMessage(m => "Firstname only allow a max to 128 charaters");

            RuleFor(p => p.LastName)
                .MaximumLength(128)
                .WithMessage(m => "Lastname only allow a max to 128 charaters");

            RuleFor(p => p.Email)
                .NotEmpty()
                .WithMessage(m => "Email is required")
                .EmailAddress()
                .WithMessage("Invalid email")
                .MustAsync(IsUniqueEmail)
                .WithMessage("Email already exist");

            RuleFor(u => u.Phone)
                .NotEmpty()
                .WithMessage("Phone number is required");

            RuleFor(u => u.Age)
                .GreaterThanOrEqualTo(18)
                .WithMessage("The contact must be 18 years or older");

            RuleFor(x => x.DateOfBirth)
                .Must(dateOfBirth => CommonHelper.IsAValidDate(dateOfBirth))
                .WithMessage("Invalid date of birth");
           
        }

        /// <summary>
        /// Asynchronously checks if the email is unique in the database.
        /// </summary>
        /// <param name="email">The email to check.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>True if the email is unique, false otherwise.</returns>
        private async Task<bool> IsUniqueEmail(string email, CancellationToken cancellationToken)
        {
            // Check if the email is unique in the database
            var contact = await _contactRepository.GetContactByEmailAsync(email, cancellationToken);
            
            return contact is null;
        }

    }
}
