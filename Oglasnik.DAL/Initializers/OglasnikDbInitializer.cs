using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Oglasnik.DAL.Entities;

namespace Oglasnik.DAL.Initializers
{
    public class OglasnikDbInitializer : DropCreateDatabaseAlways<OglasnikContext>
    {
        protected override void Seed(OglasnikContext context)
        {
            Guid bp = Guid.NewGuid();
            Guid ob = Guid.NewGuid();

            var counties = new List<CountyEntity>()
            {
                new CountyEntity
                {
                    Id=bp,
                    Name="Brodsko-posavska"

                },
                new CountyEntity
                {
                    Id=ob,
                    Name="Osječko-baranjska"
                }
            };

            var locations = new List<LocationEntity>()
            {
                new LocationEntity
                {
                    Name="Slavonski Brod",
                    CountyID=bp
                },
                new LocationEntity
                {
                    Name="Nova Gradiška",
                    CountyID=bp
                },
                new LocationEntity
                {
                    Name="Osijek",
                    CountyID=ob
                },
                new LocationEntity
                {
                    Name="Valpovo",
                    CountyID=ob
                }
            };

            context.Counties.AddRange(counties);
            context.Locations.AddRange(locations);
            context.SaveChanges();
        }
    }
}
