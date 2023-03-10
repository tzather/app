using Zuhid.BaseApi;
using Zuhid.Identity;

// Services
var builder = WebApplication.CreateBuilder(args);
var appSetting = new AppSetting(builder.Configuration);

builder.Services.AddBaseServices(appSetting.Name, appSetting.Version, appSetting.CorsOrigin);
builder.Services.AddDatabase<IdentityContext, IdentityContext>(appSetting.IdentityContext);

// app
var app = builder.Build();
app.UseBaseApp(appSetting.Name, appSetting.Version, appSetting.CorsOrigin, app.Environment);

// run
app.Run();
