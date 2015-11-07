using System;

namespace Oglasnik.Model.Common
{
    public interface ILocation
    {
        Guid Id { get; set; }
        Guid CountyID { get; set; }
        string Name { get; set; }

        ICounty County { get; set; }
    }
}