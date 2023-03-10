using Microsoft.AspNetCore.Identity;

namespace Zuhid.Identity.Entities;

public class UserEntity : IdentityUser<Guid> {
  public DateTimeOffset ModifiedDate { get; set; }
  public string? FirstName { get; set; }
  public string? LastName { get; set; }
}
