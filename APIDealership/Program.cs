using APIDealership.Interface;
using APIDealership.Repository;
using System.Data.SqlClient;

internal class Program
{
    //Creating connection to the database
    static SqlConnection? _connection;
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //repository
        //will register the class to the frame work for every class that we want to inject to the constructer
        builder.Services.AddTransient<IDealershipRepository, DealershipRepository>();
        builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
        builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();

        // Establish the connection to the tables
        var cs = @"Server=DESKTOP-MASQELN\EDANROSENSQL;Database=DealershipDb;Trusted_Connection=True;";

        _connection = new SqlConnection(cs);
        builder.Services.AddSingleton(_connection);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}