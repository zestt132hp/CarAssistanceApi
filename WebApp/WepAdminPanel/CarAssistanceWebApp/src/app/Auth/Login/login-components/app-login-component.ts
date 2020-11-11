import {Component, OnInit} from '@angular/core';
import {UserLogin} from '../../../Interfaces/UserInterface/User';

@Component({
    selector: 'app-login-user',
    templateUrl: './app-login-component.html',
    styleUrls: [ './app-login-component.html' ]
  })

export class LoginUser implements OnInit
{
  user: UserLogin;

  ngOnInit(): void {
  }
}
