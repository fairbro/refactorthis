
using AutoMapper;
using Web.Api.Core;
using Web.Api.Core.Gateways.Repositories;
using Web.Api.Core.Interfaces;
using Web.Api.Core.UseCases;
using Web.Api.Infrastructure;
using Web.Api.Infrastructure.EntityFramework;

namespace refactor_me
{
    public static class AutomapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Web.Api.Infrastructure.EntityFramework.Product, Web.Api.Core.Gateways.Repositories.Product>().ReverseMap();
            });
        }
    }
}