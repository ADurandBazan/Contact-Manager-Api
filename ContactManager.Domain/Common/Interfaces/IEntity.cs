using System;
using System.Collections.Generic;
using System.Text;

namespace ContactManager.Domain.Common.Interfaces
{
    public interface IEntity
    {
        //
        // Summary:
        //     Gets the entity ID.
        object Id { get; }
    }

    public interface IEntity<TId> : IEntity
    {
        //
        // Summary:
        //     Gets or sets the entity ID.
        new TId Id { get; set; }
    }
}
