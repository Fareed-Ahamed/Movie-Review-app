import { Component } from '@angular/core';
import { LoginService } from './welcome.service'
import { Router } from '@angular/router';
@Component({
  templateUrl: './welcome.component.html'
})
export class WelcomeComponent {
  public pageTitle = 'Welcome';
  userName: string = '';
  password: string = '';
  errorMessage: any;
  constructor(private loginService: LoginService, private router : Router) {
  }
  login() {
    window.sessionStorage.setItem("userName", this.userName);
    var request = {
      userName: this.userName,
      password: this.password
    };
    this.loginService.getUsers(request).subscribe(res => {
      window.sessionStorage.setItem("Role", res.toString());
        this.router.navigate(['/', 'products']);
      
    }, err => { this.errorMessage });
  }
}
