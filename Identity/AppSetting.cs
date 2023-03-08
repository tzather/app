
namespace Zuhid.Identity;

public class AppSetting {
  public AppSetting() { }
  public AppSetting(IConfiguration configuration) { }

  public string Name { get; set; } = "Identity";
  public string Version { get; set; } = "1.0";
  public string CorsOrigin { get; set; } = "CorsOrigin";
}
