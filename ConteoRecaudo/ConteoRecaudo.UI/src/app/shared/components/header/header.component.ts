import { Component } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})

export class HeaderComponent {
  public fluid = true;
  userName: string = "";
  private USER_KEY = 'auth-user';

  constructor(
    private authService: AuthService,
    private router: Router
  ) {
    this.userName = "John Doe";
  }

  logOut(){
    this.authService.logout();
    this.router.navigate(['/home']);
  }

}
