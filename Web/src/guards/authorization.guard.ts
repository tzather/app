import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivateChild } from '@angular/router';

@Injectable({ providedIn: 'root' })
export class AuthorizationGuard implements CanActivateChild {
  canActivateChild(childRoute: ActivatedRouteSnapshot): boolean {
    const role = (childRoute.data as any).role;
    if (role == 'IdentityAdmin') {
      return false;
    }
    return true;
  }
}
