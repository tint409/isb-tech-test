using ISBTest.DAL.Contracts;
using ISBTest.DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBTest.DAL;

public static class DataAccessRegistration
{
    private readonly static string EntitiesNamespace = typeof(Property).Namespace!;

    public static IServiceCollection AddDataAccessServices(this IServiceCollection services)
    {
        
        return services;
    }
}
