using System;

namespace UCI.Project.Domain.Entities
{
    public class Entity
    {
        public Entity()
        {
            Id = $"{Guid.NewGuid()}";
        }
        public string Id { get; set; }
    }
}
