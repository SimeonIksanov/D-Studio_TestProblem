using InvoiceMgmt.ApplicationCore.Interfaces;
using InvoiceMgmt.ApplicationCore.Services;
using InvoiceMgmt.Infrastructure.Data;
using InvoiceMgmt.Infrastructure.Data.InMemoryDB;

namespace InvoiceMgmt.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddScoped<IInvoiceService, InvoiceService>();
        builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
        builder.Services.RegisterPersistance();

        var app = builder.Build();

        // Configure the HTTP request pipeline.

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
