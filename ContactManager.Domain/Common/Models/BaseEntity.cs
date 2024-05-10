using ContactManager.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContactManager.Domain.Common.Models
{
    public class BaseEntity<TId> : IEntity<TId>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TId Id { get; set; }

        //
        // Summary:
        //     Gets the entity ID.
        object IEntity.Id => Id;
    }
}
