using AutoMapper;
using MVC_Identity.Models;

namespace MVC_Identity
{
    public static class MapConfig
    {
        public static void ConfigureMappings()
        {
            Mapper.CreateMap<ApplicationUser, AdminViewModel>();
        }
    }
}