using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Domain.Constants
{
    /// <summary>
    /// An abstract class representing various roles.
    /// </summary>
    public abstract class Roles
    {
        /// <summary>
        /// A public constant for the role name of Manager.
        /// </summary>
        public const string Manager = nameof(Manager);

        /// <summary>
        /// A public constant for the role name of Administrator.
        /// </summary>
        public const string Administrator = nameof(Administrator);

        /// <summary>
        /// A public constant for the role name of Project Administrator.
        /// </summary>
        public const string ProjectAdministrator = "Project Administrator";
    }
}
