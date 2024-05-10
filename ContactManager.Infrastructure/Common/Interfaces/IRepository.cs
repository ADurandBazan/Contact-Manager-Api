using ContactManager.Domain.Common.Interfaces;
using ContactManager.Domain.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Infrastructure.Common.Interfaces
{
    /// <summary>
    /// An interface for a generic repository.
    /// </summary>
    /// <typeparam name="TEntity">The type of entity that the repository manages.</typeparam>
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        /// <summary>
        /// Saves an element to the repository asynchronously.
        /// </summary>
        /// <param name="element">The element to save.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous save operation.</returns>
        Task SaveAsync(TEntity element, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an element in the repository asynchronously.
        /// </summary>
        /// <param name="element">The element to update.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous update operation.</returns>
        Task UpdateAsync(TEntity element, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an element from the repository asynchronously.
        /// </summary>
        /// <param name="element">The element to delete.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        Task DeleteAsync(TEntity element, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets an element from the repository by its ID asynchronously.
        /// </summary>
        /// <typeparam name="TId">The type of the ID.</typeparam>
        /// <param name="elementId">The ID of the element to get.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous get operation.</returns>
        Task<TEntity> GetByIdAsync<TId>(TId elementId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a collection of elements from the repository by their IDs asynchronously.
        /// </summary>
        /// <typeparam name="TId">The type of the ID.</typeparam>
        /// <param name="elementIds">The IDs of the elements to get.</param>
        /// <param name="cancellationToken">A cancellation token to cancel the operation.</param>
        /// <returns>A task that represents the asynchronous get operation.</returns>
        Task<IEnumerable<TEntity>> GetAllByIdsAsync<TId>(IList<TId> elementIds, CancellationToken cancellationToken = default);

        /// <summary>
        /// Saves an element to the repository.
        /// </summary>
        /// <param name="element">The element to save.</param>
        void Save(TEntity element);

        /// <summary>
        /// Updates an element in the repository.
        /// </summary>
        /// <param name="element">The element to update.</param>
        void Update(TEntity element);

        /// <summary>
        /// Deletes an element from the repository.
        /// </summary>
        /// <param name="element">The element to delete.</param>
        void Delete(TEntity element);

        /// <summary>
        /// Gets an element from the repository by its ID.
        /// </summary>
        /// <typeparam name="TId">The type of the ID.</typeparam>
        /// <param name="elementId">The ID of the element to get.</param>
        /// <returns>The element with the specified ID.</returns>
        TEntity GetById<TId>(TId elementId);
    }
}
