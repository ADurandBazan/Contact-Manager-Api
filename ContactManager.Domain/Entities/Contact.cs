using ContactManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Domain.Entities
{
    /// <summary>
    /// A class representing a contact entity.
    /// </summary>
    public class Contact : BaseEntity<Guid>
    {
        /// <summary>
        /// The first name of the contact.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the contact.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The email address of the contact.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The date of birth of the contact.
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// The phone number of the contact.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// The user who owns this contact.
        /// </summary>
        public virtual User Owner { get; set; }
    }
}
