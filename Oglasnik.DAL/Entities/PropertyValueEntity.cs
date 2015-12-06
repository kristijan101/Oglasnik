using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Entities
{
    public class PropertyValueEntity : Contracts.IEntity
    {
        public Guid Id { get; set; }
        public string Value { get; set; }
        public Guid PropertyTypeId { get; set; }

        public virtual PropertyTypeEntity PropertyType { get; set; }
    }
}
