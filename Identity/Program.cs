using Microsoft.AspNetCore.Identity;
using Zuhid.BaseApi;
using Zuhid.Identity;
using Zuhid.Identity.Entities;

// Services
var builder = WebApplication.CreateBuilder(args);
var appSetting = new AppSetting(builder.Configuration);

builder.Services.AddBaseServices(appSetting.Name, appSetting.Version, appSetting.CorsOrigin);
builder.Services.AddDatabase<IdentityContext, IdentityContext>(appSetting.IdentityContext);
builder.Services.AddIdentity<UserEntity, RoleEntity>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

// app
var app = builder.Build();
app.UseBaseApp(appSetting.Name, appSetting.Version, appSetting.CorsOrigin, app.Environment);

// run
app.Run();
