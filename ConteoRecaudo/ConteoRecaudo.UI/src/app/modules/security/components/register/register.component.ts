import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { Register } from 'src/app/core/models/register';
import { RegisterResponse } from 'src/app/core/models/register-response';
import { UserService } from 'src/app/core/services/user.service';
import { confirmPasswordValidator } from 'src/app/core/utils/confirm-password-validation.utils';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})

export class RegisterComponent implements OnInit {

  form: FormGroup = new FormGroup({
    name: new FormControl(),
    lastName: new FormControl(''),
    userName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    repeatPassword: new FormControl('')
  });

  submitted = false;
  messaje = '';
  registerModel: Register;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private router: Router
  ){ 
    this.registerModel = new Register('','','','','')
   }

  ngOnInit(): void {
    this.form = this.formBuilder.group({
      name: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(20),
        ],
      ],
      lastName: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(20),
        ],
      ],
      userName: [
        '',
        [
          Validators.pattern("[a-zA-Z0-9_-]*"),
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(20),
        ],
      ],
      email: [
        '',
        [
          Validators.email,
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(50),
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
      repeatPassword: [
        '',
        [
          Validators.required,
          Validators.minLength(4),
          Validators.maxLength(50),
        ],
      ],
    },{
      Validators: confirmPasswordValidator
    });
  }

  get f(): { [key: string]: AbstractControl } {
    return this.form.controls;
  }

  registerUser(){
    this.submitted = true;

    if (this.form.invalid) {
      this.messaje = "Corrige los errores antes de continuar";
      return;
    } else if (this.form.value.password !== this.form.value.repeatPassword) {
      this.messaje = "Las contraseña y la confirmación de contraseña, no coinciden.";
      return;
    } else {
      this.messaje = '';
      this.registerModel = new Register(
        this.form.value.name,
        this.form.value.lastName,
        this.form.value.userName,
        this.form.value.password,
        this.form.value.email
      );
      this.userService.registerUser(this.registerModel)
      .subscribe((response: RegisterResponse) => {
        this.messaje = response.message;
      });
    }
  }

}
