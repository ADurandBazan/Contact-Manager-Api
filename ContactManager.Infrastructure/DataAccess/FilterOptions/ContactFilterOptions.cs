using ContactManager.Infrastructure.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.DataAccess.FilterOptions
{
    public class ContactFilterOptions : BaseFilterOptions
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
