import { Injectable } from '@angular/core';
import { ILogin, Login } from './login';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})

export class LoginService {
  private loginUrl = 'https://localhost:44343';
  constructor(private http: HttpClient) { }
  getUsers(user: any) {
    let body = JSON.stringify(user);
    return this.http.post(`${this.loginUrl}/login`, body, {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    });
  }
}
