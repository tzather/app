using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Zuhid.BaseApi;

public static class ServicesConfigurationExtension {
  public static void AddBaseServices(this IServiceCollection services, string title, string version, string corsOrigin) {
    services.AddAuthentication();
    services
      .AddControllers()
      .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
    services.AddSwaggerGen();
  }

  public static void AddDatabase<ITContext, TContext>(this IServiceCollection services, string connectionString)
  where ITContext : class
  where TContext : DbContext, ITContext {
    services.AddDbContext<TContext>(options => options
        .UseSqlServer(connectionString)
        .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking) // don't track entities
        .EnableSensitiveDataLogging() // log sql param values
      );
    services.AddScoped<ITContext, TContext>();
  }
}
