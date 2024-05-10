using ContactManager.Application.Common.Models;
using ContactManager.Application.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.ApplicationServices.Maps
{
    public class ContactDto : BaseEntityDto<string>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string OwnerId { get; set; } = string.Empty;
        public int Age => CommonHelper.GetAge(DateOfBirth);

    }
}
