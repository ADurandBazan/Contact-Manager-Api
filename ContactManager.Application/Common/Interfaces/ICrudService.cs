using ContactManager.Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Application.Common.Interfaces
{
    /// <summary>
    /// An interface for CRUD (Create, Read, Update, Delete) operations on a given model.
    /// </summary>
    /// <typeparam name="TModel">The type of the model.</typeparam>
    public interface ICrudService<TModel> where TModel : class
    {
        /// <summary>
        /// Creates a new instance of the model asynchronously.
        /// </summary>
        /// <param name="element">The model instance to create.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The created model instance.</returns>
        Task<TModel> CreateAsync(TModel element, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing instance of the model asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the model instance to update.</param>
        /// <param name="element">The updated model instance.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The updated model instance.</returns>
        Task UpdateAsync<TId>(TId id, TModel element, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing instance of the model asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the model instance to delete.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task DeleteAsync<TId>(TId id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an instance of the model by its unique identifier asynchronously.
        /// </summary>
        /// <param name="elementId">The unique identifier of the model instance to get.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>The model instance with the given identifier.</returns>
        Task<TModel> GetByIdAsync<TId>(TId elementId, CancellationToken cancellationToken = default);
    }
}
