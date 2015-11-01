using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Entities
{
    public class AdEntity : Contracts.IEntity
    {
        //TODO: trebala bi postojati veza između Ad i PropertyValue

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
        public bool Active { get; set; }
        public Guid CategoryID { get; set; }
        public string UserID { get; set; }

        public virtual CategoryEntity Category { get; set; }
        public virtual UserEntity User { get; set; }
    }
}
