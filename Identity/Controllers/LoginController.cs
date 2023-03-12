using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Zuhid.Identity.Models;

namespace Zuhid.Identity.Controllers;

[ApiController]
[AllowAnonymous]
[Route("[controller]")]
public class LoginController : ControllerBase {
  private readonly SecurityService securityService;

  public LoginController(SecurityService securityService) {
    this.securityService = securityService;
  }

  [AllowAnonymous]
  [HttpPost()]
  public LoginResponse Login([FromBody] Login model) {
    return new LoginResponse {
      Token = $"{model.UserName}:{model.Password}"
    };
  }

  [AllowAnonymous]
  [HttpPost("AddUser")]
  public async Task AddUser([FromBody] Login model) {
    await securityService.AddUser(model.UserName, model.Password);
  }


  [HttpGet("HashPassword")]
  public string HashPassword([FromBody] Login model) {
    return securityService.HashPassword(model.Password);
  }

  [HttpGet("VerifyPassword")]
  public bool VerifyPasswordAsync(string hashPassword) {
    return securityService.VerifyPassword("admin@company.com", "P@ssw0rd", hashPassword);
  }

  [HttpGet("EmailToken")]
  public async Task<string> EmailToken() {
    return await securityService.EmailToken("admin@company.com");
  }

  [HttpGet("VerifyEmailToken")]
  public async Task<bool> VerifyEmailToken() {
    var token = "CfDJ8J0gITgZb2VIlbDPsSK3+IGwWirao8TDCUFPIEUIOpNGfxQW7heOil6lVMVOoZTKEGNJZAs7H2Qv5kQMcVIF0UFv8+MuJsHuNwBTANF/VJK8ZFSrSXa8GUUdzDgXOybr1IS8sRyk9eB7IkYvFF2Ibh068pKluBNfPjVqTIrT7k+ESTIX72SwkarpT1yr3c17au+WgYnIYG6wa3FBbLRQrIgdQz8mB76lDBYhQLcgKgGKYpVDXEjSk0Ki+dII2m1BRQ==";
    return await securityService.VerifyEmailToken("admin@company.com", token);
  }

  [AllowAnonymous]
  [HttpGet("PhoneToken")]
  public async Task<string> PhoneToken() {
    return await securityService.PhoneToken("admin@company.com");
  }

  [HttpGet("VerifyPhoneToken")]
  public async Task<bool> VerifyPhoneToken() {
    return await securityService.VerifyPhoneToken("admin@company.com", "417175");
  }


  [HttpGet("TfaToken")]
  public async Task<string> TfaToken() {
    return await securityService.TfaToken("admin@company.com");
  }

  [HttpGet("VerifyTfaToken")]
  public async Task<bool> VerifyTfaToken() {
    return await securityService.VerifyTfaToken("admin@company.com", "805835");
  }
}
