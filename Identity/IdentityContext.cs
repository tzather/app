using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zuhid.BaseApi;
using Zuhid.Identity.Entities;

namespace Zuhid.Identity;

public class IdentityContext : IdentityDbContext<UserEntity, RoleEntity, Guid>, IContext {
  public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }
}
