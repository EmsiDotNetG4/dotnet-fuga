using System.Text.Json.Serialization;
using EMSI.Fuga.Config;
using EMSI.Fuga.Infrastructure.Database;
using EMSI.Fuga;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        });

        //swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //config
        builder.Services.Configure<DatabaseConfig>(builder.Configuration.GetRequiredSection("Database"));

        var databaseConfig = builder.Configuration.GetRequiredSection("Database").Get<DatabaseConfig>();

        // http context
        builder.Services.AddHttpContextAccessor();

        // infrastructure
        builder.Services.AddDatabaseDependencies(databaseConfig!.ConnectionString);

        // services
        builder.Services.AddServiceDependencies();

        // logging
        builder.Logging.ClearProviders();
        builder.Logging.AddConsole();

        // cors
        builder.Services.AddCors();

        //mappers

        await RunApiAsync(builder);
    }

    private static async Task RunApiAsync(WebApplicationBuilder builder)
    {
        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        await app.RunAsync();
    }
}