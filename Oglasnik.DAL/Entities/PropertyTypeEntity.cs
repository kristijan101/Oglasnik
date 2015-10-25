using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Entities
{
    public class PropertyTypeEntity : Contracts.IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AdEntity> Ads { get; set; }
        public virtual ICollection<PropertyValueEntity> PropertyValues { get; set; }
    }
}
