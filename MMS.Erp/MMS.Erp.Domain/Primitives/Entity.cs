using System;

namespace MMS.Erp.Domain.Primitives;

public abstract class Entity
{
    protected Entity(Guid id) => Id = id;

    protected Entity()
    {

    }

    public Guid Id { get; set; }
}
