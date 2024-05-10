using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.Common.Exceptions
{
    /// <summary>
    /// An exception class for when an element is not found.
    /// </summary>
    public class ElementNotFoundException : Exception
    {
        public ElementNotFoundException(string message) : base(message)
        {
        }
    }
}
