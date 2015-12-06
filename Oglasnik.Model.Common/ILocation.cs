using System;

namespace Oglasnik.Model.Common
{
    public interface ILocation
    {
        Guid? Id { get; set; }
        string Name { get; set; }
        Guid CountyID { get; set; }
    }
}