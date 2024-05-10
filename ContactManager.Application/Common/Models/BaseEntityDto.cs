using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.Common.Models
{
    public class BaseEntityDto<TId>
    {
        public TId Id { get; set; } = default!;
    }
}
