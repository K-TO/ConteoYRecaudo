import { Component } from '@angular/core';
import { AuthService } from 'src/app/core/services/auth.service';

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
    private authService: AuthService
  ) {
    this.userName = "John Doe";
  }

  logOut(){
    console.log('cloc')
    this.authService.logout();
  }

}
