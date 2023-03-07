using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Zuhid.Identity.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : ControllerBase {
  public LoginController() { }

  [AllowAnonymous]
  [HttpGet()]
  public string Get() {
    return "Hello World";
  }
}
