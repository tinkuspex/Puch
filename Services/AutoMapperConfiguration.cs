using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class AutoMapperConfiguration
    {
        public static IServiceCollection AddCustomAutomapper(this IServiceCollection services)
        {

            var mapperConfig = new MapperConfiguration(mc =>
            {
               
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
