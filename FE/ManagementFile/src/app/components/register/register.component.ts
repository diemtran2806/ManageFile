import { Component } from '@angular/core';
import { UserRegister } from './../../interfaces/user';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss'],
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup = new FormGroup({});

  constructor(
    private api: ServerHttpService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.registerForm = fb.group(
      {
        email: ['', [Validators.required]],
        username: ['', [Validators.required, Validators.minLength(8)]],
        fullName: ['', [Validators.required]],
        password: ['', [Validators.required, Validators.minLength(8)]],
        confirmPassword: ['', [Validators.required, Validators.minLength(8)]],
      },
      { validator: this.ConfirmedValidator('password', 'confirmPassword') }
    );
  }

  ngOnInit(): void {}

  registerAccount() {
    this.api
      .createNewAccount(this.registerForm.value)
      .then((res) => {
        if (res.status === 200) this.router.navigate(['login']);
      })
      .catch((err) => {
        console.log(err);
      });
  }

  ConfirmedValidator(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];
      if (
        matchingControl.errors &&
        !matchingControl.errors?.['confirmedValidator']
      ) {
        return;
      }
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ confirmedValidator: true });
      } else {
        matchingControl.setErrors(null);
      }
    };
  }
}
