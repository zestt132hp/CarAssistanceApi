import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import {UserLogin} from '../../../Interfaces/UserInterface/User';
import {Token} from '@angular/compiler';

@Injectable({providedIn: 'root'})

export class LoginService {
    private CarAssistanceApiUrl = '';
    private JBToken: Token;

    httpOptions = {
        headers: new HttpHeaders({ContentType: 'application/json'})
    };

    constructor(private http: HttpClient){}

LogIn(user: UserLogin): void {
      const accessUser = this.http.get<UserLogin>(this.CarAssistanceApiUrl).pipe();
  }
    /*TODO: Add http requests service and in this file add communication to login use CarAssitanceApi */
}
