using Entity_Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework.Entities
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}
