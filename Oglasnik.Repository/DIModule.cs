using Oglasnik.DAL;
using Oglasnik.DAL.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oglasnik.Repository.Common;
using Oglasnik.Model.Common;

namespace Oglasnik.Repository
{
    public class DIModule : Ninject.Modules.NinjectModule
    {
        public override void Load()
        {
            Bind<IOglasnikContext>().To<OglasnikContext>();
            Bind<ILocationRepository>().To<LocationRepository>();
            Bind<ICountyRepository>().To<CountyRepository>();
            Bind(typeof(IRepository<>)).To(typeof(Repository<>));
        }
    }
}
