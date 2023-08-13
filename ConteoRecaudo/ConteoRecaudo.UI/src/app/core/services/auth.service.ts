import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { AuthenticationResponse } from '../models/authenticationResponse';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  apiUrl = `${environment.apiUrl}/api/Auth`;
  authResponse: any;
  private USER_KEY = 'auth-user';

  constructor(private http: HttpClient) {}

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
    }),
  };

  getToken(
    username: string,
    password: string
  ): Observable<AuthenticationResponse> {
    return this.http
      .post<AuthenticationResponse>(
        this.apiUrl,
        JSON.stringify({ username, password }),
        this.httpOptions
      )
      .pipe(retry(1), catchError(this.handleError));
  }

  logout() {
    window.sessionStorage.removeItem(this.USER_KEY);
    window.sessionStorage.removeItem('token');
  }

  isAuthenticated(): boolean {
    const user = window.sessionStorage.getItem(this.USER_KEY);
    return user ? true : false;
    // if (user) {
    //   return true;
    // }

    // return false;
  }

  getCurrentToken() {
    let token = window.sessionStorage.getItem('token');
    if (token && token != '') {
      return token;
    } else {
      return '';
    }
  }

  isTokenExpired(token: string) {
    const expiry = JSON.parse(atob(token.split('.')[1])).exp;
    return expiry * 1000 < Date.now();
  }

  // Error handling
  handleError(error: any) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      // Get client-side error
      errorMessage = error.error.message;
    } else {
      // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.warn(errorMessage);
    return throwError(() => {
      return errorMessage;
    });
  }
}
