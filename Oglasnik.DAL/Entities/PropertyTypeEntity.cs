using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Entities
{
    public class PropertyTypeEntity : Contracts.IEntity
    {      
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryID { get; set; }
        
        public virtual CategoryEntity Category { get; set; }
        public virtual ICollection<PropertyValueEntity> PropertyValues { get; set; }
    }
}
