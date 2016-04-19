using AutoMapper;

namespace Oglasnik.WebAPI.App_Start
{
    public static class AutoMapperConfig
    {
        /// <summary>
        /// Add initial configuration for AutoMapper here.
        /// </summary>
        public static void Initialize()
        {
            Mapper.Initialize(cfg => {
                cfg.AddProfile<Model.AutoMapperModelConfig>();
                cfg.AddProfile<Repository.AutoMapperRepositoryConfig>();
                cfg.AddProfile<AutoMapperWebApiConfig>();
            });
        }
    }
}