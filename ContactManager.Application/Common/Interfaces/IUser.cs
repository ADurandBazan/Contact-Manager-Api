using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.Common.Interfaces
{
    /// <summary>
    /// Interface for current user object.
    /// </summary>
    public interface IUser
    {
        string? Username { get; }
    }
}
