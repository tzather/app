import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/models';
import { IdentityService } from 'src/services';

@Component({
  selector: 'zc-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  public model: Login = {
    username: 'admin@company.com',
    password: 'P@ssw0rd',
    rememberMe: true,
  };

  constructor(private router: Router, private identityService: IdentityService) {}

  async login() {
    this.identityService.login(this.model).then(() => this.router.navigate(['/user']));
  }
}
