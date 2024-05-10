using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.Common.Models
{
    /// <summary>
    /// A paginated list of items.
    /// </summary>
    /// <typeparam name="T">The type of items in the list.</typeparam>
    public class PaginatedList<T>
    {
        /// <summary>
        /// Gets the items in the list.
        /// </summary>
        public IReadOnlyCollection<T> Items { get; }

        /// <summary>
        /// Gets the current page number.
        /// </summary>
        public int PageNumber { get; }

        /// <summary>
        /// Gets the total number of pages.
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Gets the total number of items.
        /// </summary>
        public int TotalCount { get; }

        public PaginatedList(IReadOnlyCollection<T> items, int count, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalCount = count;
            Items = items;
        }

        public bool HasPreviousPage => PageNumber > 1;

        public bool HasNextPage => PageNumber < TotalPages;

        public static async Task<PaginatedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            try
            {
                var count = await source.CountAsync();
                var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

                return new PaginatedList<T>(items, count, pageNumber, pageSize);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
