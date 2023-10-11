import { Component } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { StateService } from 'src/app/Services/stare/state.service';
import { CurrentUser } from 'src/app/interfaces/user';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  username: string = '';
  registerForm: FormGroup = new FormGroup({});

  constructor(
    private api: ServerHttpService,
    private fb: FormBuilder,
    private router: Router,
    private currentUserState: StateService
  ) {
    this.registerForm = fb.group({
      username: ['', [Validators.required, Validators.minLength(8)]],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }

  loginAccount() {
    this.api
      .loginAccount(this.registerForm.value)
      .then((res) => {
        if (res.status === 200) {
          console.log(res.status);
          this.currentUserState.setCurrentUser(res.data);
          localStorage.setItem('token', res.data?.token);
          localStorage.setItem('username', res.data?.username);
          localStorage.setItem('email', res.data?.email);
          this.router.navigate(['/']);
        }
      })
      .catch((err) => {
        console.log(err);
      });
  }

  saveUsername() {
    localStorage.setItem('username', this.username);
  }
}
