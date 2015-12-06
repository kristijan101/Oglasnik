using Ninject.Modules;
using Oglasnik.Model.Common;
using Oglasnik.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oglasnik.Services
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ILocationService>().To<LocationService>();
            Bind<ICountyService>().To<CountyService>();
        }
    }
}
