import { Injectable } from '@angular/core';
import { Router, CanActivate } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Injectable()

export class AuthGuardService implements CanActivate {
  constructor(public auth: AuthService, public router: Router) {}
  canActivate(): boolean {
    let token = this.auth.getCurrentToken();
    if (!this.auth.isAuthenticated() || this.auth.isTokenExpired(token)) {
      this.router.navigate(['/auth']);
      return false;
    }
    return true;
  }
}