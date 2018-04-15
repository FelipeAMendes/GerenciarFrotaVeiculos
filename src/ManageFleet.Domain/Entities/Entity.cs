using System;

namespace ManageFleet.Domain.Entities
{
    public abstract class Entity
    {
        public int Id { get; set; }

        public abstract bool IsValid();
    }
}