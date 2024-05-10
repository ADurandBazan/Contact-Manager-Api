using ContactManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Domain.Entities
{
    /// <summary>
    /// A class representing a user entity.
    /// </summary>
    public class User : BaseEntity<Guid>
    {
        /// <summary>
        /// The first name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The username of the user.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The password of the user.
        /// </summary>
        public string Password { get; set; }
    }
}
