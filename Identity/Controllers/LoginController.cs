using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Zuhid.Identity.Entities;
using Zuhid.Identity.Models;

namespace Zuhid.Identity.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase {
  private readonly UserManager<UserEntity> userManager;

  public LoginController(UserManager<UserEntity> userManager) {
    this.userManager = userManager;
  }

  [AllowAnonymous]
  [HttpPost()]
  public LoginResponse Login([FromBody] Login model) {
    return new LoginResponse {
      Token = $"{model.UserName}:{model.Password}"
    };
  }

  [AllowAnonymous]
  [HttpGet("HashPassword")]
  public string HashPassword([FromBody] Login model) {
    var userEntity = new UserEntity {
      UserName = model.UserName
    };
    return userManager.PasswordHasher.HashPassword(userEntity, model.Password);
  }

  [AllowAnonymous]
  [HttpGet("VerifyPassword")]
  public async Task<bool> VerifyPasswordAsync(string hashPassword) {
    var userEntity = new UserEntity {
      UserName = "admin@company.com"
    };
    userEntity.PasswordHash = userManager.PasswordHasher.HashPassword(userEntity, "P@ssw0rd");
    return await userManager.CheckPasswordAsync(userEntity, "P@ssw0rd");
  }

  [AllowAnonymous]
  [HttpGet("EmailToken")]
  public async Task<string> EmailToken() {
    var userEntity = new UserEntity {
      UserName = "admin@company.com",
      PasswordHash = "AQAAAAIAAYagAAAAEOUTIH/hC5Mt1IbBxleSaD/A8pUPj/mlVJJ0dTYAu0I5SaWHMdPxyLFfPBwGpi3gDg==",
      Id = Guid.NewGuid(),
      SecurityStamp = "DateTime.UtcNow.Ticks.ToString()"
    };
    return await userManager.GeneratePasswordResetTokenAsync(userEntity);
  }


  [AllowAnonymous]
  [HttpGet("VerifyEmailToken")]
  public async Task<bool> VerifyEmailToken() {
    var userEntity = new UserEntity {
      UserName = "admin@company.com",
      PasswordHash = "AQAAAAIAAYagAAAAEOUTIH/hC5Mt1IbBxleSaD/A8pUPj/mlVJJ0dTYAu0I5SaWHMdPxyLFfPBwGpi3gDg==",
      Id = Guid.NewGuid(),
      SecurityStamp = "DateTime.UtcNow.Ticks.ToString()"
    };
    return await userManager.VerifyUserTokenAsync(userEntity, "", "", "CfDJ8J0gITgZb2VIlbDPsSK3+IGL496uUZ6NJMtLHHXlIBnprpgaDVwonuIcQFN78Cb2SCwZvgRi/8DSaEi4FgvHTjW7RLW7hv35DugvRgVC0i7mjKosBCAVG0bqCQ2ZM+ogNbjPV/LYxCNQcqUdqbypcZF9d17/+v+ZRSzHg+lfmStRKX0LKWYULjg3o9VR5lJtrB95NbwzmMp3JuqV7SlEdE6jwANNbvzYp0rlaoSkOwmf");
  }

  [AllowAnonymous]
  [HttpGet("TotpToken")]
  public async Task<string> TotpToken() {
    var userEntity = new UserEntity {
      UserName = "admin@company.com",
      PasswordHash = "AQAAAAIAAYagAAAAEOUTIH/hC5Mt1IbBxleSaD/A8pUPj/mlVJJ0dTYAu0I5SaWHMdPxyLFfPBwGpi3gDg==",
      Id = Guid.NewGuid(),
      SecurityStamp = "DateTime.UtcNow.Ticks.ToString()"
    };
    return await userManager.GenerateChangePhoneNumberTokenAsync(userEntity, "7207207200");
  }

}
