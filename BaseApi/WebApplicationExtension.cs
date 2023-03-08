namespace Zuhid.BaseApi;

public static class WebApplicationExtension {
  public static void UseBaseApp(this WebApplication app, string name, string version, string corsOrigin, IWebHostEnvironment env) {
    if (env.IsDevelopment()) {
      app.UseDeveloperExceptionPage();
    }
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(corsOrigin);
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.UseEndpoints(endpoints => {
      // on the base page, show a simple message
      endpoints.MapGet("/", async context => await context.Response.WriteAsync("<html><body style='padding:100px 0;text-align:center;font-size:xxx-large;'>Api is running<br/><br/><a href='/swagger'>View Swagger</a></body></html>"));
      endpoints.MapControllers();
    });
  }
}
