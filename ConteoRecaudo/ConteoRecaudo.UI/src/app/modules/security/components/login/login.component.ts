import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { FormControl } from '@angular/forms';
import { AuthService } from 'src/app/core/services/auth.service';
import { Router } from '@angular/router';
import { AuthenticationResponse } from 'src/app/core/models/authenticationResponse';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})

export class LoginComponent implements OnInit {
  private USER_KEY = 'auth-user';
  form: FormGroup = new FormGroup({
    username: new FormControl(''),
    password: new FormControl(''),
  });
  submitted = false;
  isLogged = false;
  messaje = '';

  constructor(
    private formBuilder: FormBuilder,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (this.isLoggedIn()) {
      this.isLogged = true;
    }

    this.form = this.formBuilder.group({
      username: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(20),
        ],
      ],
      password: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50),
        ],
      ],
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  onSubmit(): void {
    this.submitted = true;
    if (this.form.invalid) {
      return;
    }
    this.login(this.form.value.username, this.form.value.password);
  }

  onReset(): void {
    this.submitted = false;
    this.form.reset();
  }

  login(userName: string, password: string) {
    return this.authService
      .getToken(userName, password)
      .subscribe((data: AuthenticationResponse) => {
        if (data.errorMessage && data.errorMessage != '') {
          this.messaje = data.errorMessage;
        } else {
          this.messaje = '';
          window.sessionStorage.removeItem(this.USER_KEY);
          window.sessionStorage.removeItem('token');
          window.sessionStorage.setItem(this.USER_KEY, JSON.stringify(data));
          window.sessionStorage.setItem('token', data.token);
          this.router.navigate(['/home']);
        }
      });
  }

  clean(): void {
    window.sessionStorage.clear();
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(this.USER_KEY);
    if (user) {
      return JSON.parse(user);
    }

    return {};
  }

  isLoggedIn(): boolean {
    const user = window.sessionStorage.getItem(this.USER_KEY);
    if (user) {
      return true;
    }

    return false;
  }
}
