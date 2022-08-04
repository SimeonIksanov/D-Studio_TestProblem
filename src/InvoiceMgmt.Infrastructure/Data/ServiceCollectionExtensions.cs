using System;
using InvoiceMgmt.Infrastructure.Data.InMemoryDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceMgmt.Infrastructure.Data;

public static class ServiceCollectionExtensions
{
    public static void RegisterPersistance(this IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("Invoices"), ServiceLifetime.Scoped);
    }
}

