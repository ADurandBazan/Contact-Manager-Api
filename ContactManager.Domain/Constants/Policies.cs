using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Domain.Constants
{
    // <summary>
    /// An abstract class representing various policies.
    /// </summary>
    public abstract class Policies
    {
        /// <summary>
        /// A public constant for the policy name of DeleteContactPolicy.
        /// Allow delete a contact.
        /// </summary>
        public const string DeleteContactPolicy = nameof(DeleteContactPolicy);
    }
}
