using System;

namespace MMS.Erp.Domain.Primitives;

public abstract class Entity
{
    protected Entity(int id) => Id = id;

    protected Entity()
    {

    }

    public int Id { get; set; }
}
