using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework.Repositories
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}
