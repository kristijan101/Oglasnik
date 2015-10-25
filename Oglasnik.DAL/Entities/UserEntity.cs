using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.DAL.Entities
{
    public class UserEntity : IdentityUser
    {
        public virtual ICollection<AdEntity> Ads { get; set; }
    }
}
