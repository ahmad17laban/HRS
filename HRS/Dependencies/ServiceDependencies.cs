using HRS.Interfaces;
using HRS.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRS.Dependencies
{
    public static class ServiceDependencies
    {
        public static void AddServiceDependencies( this  IServiceCollection services)
        {


            services.AddTransient<IEmployeeService, EmployeeService>();
        }
    }
}
