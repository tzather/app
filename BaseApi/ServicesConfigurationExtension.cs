using System.Text.Json.Serialization;

namespace Zuhid.BaseApi;

public static class ServicesConfigurationExtension {
  public static void AddBaseServices(this IServiceCollection services, string title, string version, string corsOrigin) {
    services.AddAuthentication();

    services.AddCors(options => options.AddPolicy(corsOrigin, builder => builder.WithOrigins(corsOrigin)
      .AllowAnyHeader()
      .AllowAnyMethod()
      .AllowCredentials()
    ));

    services
      .AddControllers()
      .AddJsonOptions(options => options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull);
    services.AddSwaggerGen();
  }
}
