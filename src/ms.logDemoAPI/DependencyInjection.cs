using Microsoft.Extensions.DependencyInjection;
using ms.logBasic.Data;
using ms.logBasic.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ms.logDemoAPI
{
    public class DependencyInjection
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IContactRepository, ContactRepository>();
         
        }
    }
}
