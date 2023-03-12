using Microsoft.AspNetCore.Identity;
using Zuhid.Identity.Entities;

namespace Zuhid.Identity;

public class SecurityService {
  private readonly UserManager<UserEntity> userManager;

  public SecurityService(UserManager<UserEntity> userManager) {
    this.userManager = userManager;
  }

  public async Task AddUser(string username, string password) {
    await userManager.CreateAsync(new UserEntity {
      Email = username,
      UserName = username
    }, password);
  }

  public string HashPassword(string password) {
    return userManager.PasswordHasher.HashPassword(new(), password);
  }

  public bool VerifyPassword(string username, string password, string hashPassword) {
    var result = userManager.PasswordHasher.VerifyHashedPassword(new(), hashPassword, password);
    return result == PasswordVerificationResult.Success;
  }

  public async Task<string> EmailToken(string email) {
    var userEntity = await userManager.FindByEmailAsync(email);
    if (userEntity == null) {
      return string.Empty;
    }
    return await userManager.GenerateEmailConfirmationTokenAsync(userEntity);
  }

  public async Task<bool> VerifyEmailToken(string email, string token) {
    var userEntity = await userManager.FindByEmailAsync(email);
    if (userEntity == null) {
      return false;
    }
    return (await userManager.ConfirmEmailAsync(userEntity, token)).Succeeded;
  }

  public async Task<string> PhoneToken(string email) {
    var userEntity = await userManager.FindByEmailAsync(email);
    if (userEntity == null) {
      return string.Empty;
    }
    return await userManager.GenerateChangePhoneNumberTokenAsync(userEntity, userEntity.PhoneNumber ?? "");
  }

  public async Task<bool> VerifyPhoneToken(string email, string token) {
    var userEntity = await userManager.FindByEmailAsync(email);
    if (userEntity == null) {
      return false;
    }
    // update database column "PhoneNumberConfirmed"
    var result = await userManager.ChangePhoneNumberAsync(userEntity, userEntity.PhoneNumber ?? "", token);
    return result.Succeeded;
  }

  public async Task<bool> VerifyPhoneTokenPostConfirmed(string email, string token) {
    var userEntity = await userManager.FindByEmailAsync(email);
    if (userEntity == null) {
      return false;
    }
    // Does NOT update database column "PhoneNumberConfirmed"
    return await userManager.VerifyChangePhoneNumberTokenAsync(userEntity, userEntity.PhoneNumber ?? "", token);
  }

  public async Task<string> TfaToken(string email) {
    var token = string.Empty;
    var userEntity = await userManager.FindByEmailAsync(email);
    if (userEntity != null) {
      // if ((await userManager.ResetAuthenticatorKeyAsync(userEntity)).Succeeded) {
      token = await userManager.GetAuthenticatorKeyAsync(userEntity);
      // }
    }
    return token ?? string.Empty;
  }

  public async Task<bool> VerifyTfaToken(string email, string token) {
    var userEntity = await userManager.FindByEmailAsync(email);
    if (userEntity != null) {
      return await userManager.VerifyTwoFactorTokenAsync(userEntity, userManager.Options.Tokens.AuthenticatorTokenProvider, token);
    }
    return false;
  }
}
