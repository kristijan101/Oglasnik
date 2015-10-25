using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Entities
{
    public class AdEntity : Contracts.IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
        public int CategoryID { get; set; }
        public int UserID { get; set; }

        public virtual CategoryEntity Category { get; set; }
        public virtual ICollection<PropertyTypeEntity> Properties { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
