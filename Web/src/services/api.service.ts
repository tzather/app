import { Injectable } from '@angular/core';
import { ToastService } from './toast.service';
import { TokenService } from './token.service';

@Injectable({ providedIn: 'root' })
export class ApiService {
  constructor(private tokenService: TokenService, public toastService: ToastService) {}

  async get(url: string, errorMessage?: string): Promise<any> {
    return await this.fetchApi('get', url, null, errorMessage);
  }

  async post(url: string, model: any, errorMessage?: string): Promise<any> {
    return await this.fetchApi('post', url, model, errorMessage);
  }

  async put(url: string, model: any, errorMessage?: string): Promise<any> {
    return await this.fetchApi('put', url, model, errorMessage);
  }

  async delete(url: string, errorMessage?: string): Promise<any> {
    return await this.fetchApi('delete', url, null, errorMessage);
  }

  async getAsset(url: string): Promise<any> {
    var response = await fetch(url, {
      cache: 'force-cache',
    });
    return await response.json();
  }

  private async fetchApi(method: string, url: string, model: any, errorMessage?: string): Promise<any> {
    let identityToken = await this.tokenService.token;
    return fetch(url, {
      method: method,
      headers: {
        'Content-Type': 'application/json',
        Authorization: identityToken ? `Bearer ${identityToken}` : '',
      },
      body: model ? JSON.stringify(model) : null,
    }).then((response) => {
      if (response.ok) {
        return response.json().then((m) => m);
      } else {
        this.toastService.error(errorMessage ? errorMessage : `Failed to ${method}  ${url}`);
        return null;
      }
    });
  }
}
