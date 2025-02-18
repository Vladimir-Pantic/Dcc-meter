using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DccMeter.Api.Domain.Models;
using DccMeter.Repository.SQLServer.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DccMeterSqlServerRepositoryServiceCollectionExtensions
    {
        public static IServiceCollection AddDccMeterSqlServerRepository(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction = null)
        {


            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<DccMeter.Api.Domain.Models.User, DccMeter.Repository.SQLServer.Models.User>();
                //config.CreateMap<>
            });

            services.AddDbContext<DccMeterContext>(optionsAction);

            return services;
        }
    }
}
