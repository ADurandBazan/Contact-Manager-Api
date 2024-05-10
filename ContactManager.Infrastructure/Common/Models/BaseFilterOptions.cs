using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.Common.Models
{
    /// <summary>
    /// A base class for filter options.
    /// </summary>
    public class BaseFilterOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether the results should be sorted in descending order.
        /// </summary>
        public bool IsDescending { get; set; }
    }
}
