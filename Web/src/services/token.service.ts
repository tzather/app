import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class TokenService {
  get token(): any {
    let value = sessionStorage.getItem('identityToken');
    return value ? JSON.parse(value) : {};
  }
  set token(value: any) {
    sessionStorage.setItem('identityToken', JSON.stringify(value));
  }
  public isAuthenticated(): boolean {
    return this.token != null && this.token.length > 0;
  }
}
