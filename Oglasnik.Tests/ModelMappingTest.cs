using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Oglasnik.Model;
using Oglasnik.DAL.Entities;
using System.Collections.Generic;
using AutoMapper;

namespace Oglasnik.Tests
{
    [TestClass]
    public class ModelMappingTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Oglasnik.WebAPI.App_Start.AutoMapperConfig.Initialize();
            //arrange
            CountyEntity ctyEntity = new CountyEntity
            {
                Id = Guid.NewGuid(),
                Name = "Brodsko-posavska"
            };

            ctyEntity.Locations = new List<LocationEntity>()
            {
               new LocationEntity {
                        Id = Guid.NewGuid(),
                        Name = "Slavonski Brod",
                        CountyID = ctyEntity.Id
                }
            };

            //act
            County cty = Mapper.Map<County>(ctyEntity);

            //assert
            Assert.AreEqual(ctyEntity.Id, cty.Id);
            Assert.AreEqual(ctyEntity.Locations.Count, cty.Locations.Count);
            
        }
    }
}
