import { CurrentUser } from './../../interfaces/user';
import { Component, OnInit } from '@angular/core';
import {
  faGear,
  faMagnifyingGlass,
  faPlus,
  faFile,
} from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';
import { StateService } from 'src/app/Services/stare/state.service';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss'],
})
export class MainLayoutComponent implements OnInit {
  faGear = faGear;
  faSearch = faMagnifyingGlass;
  faPlus = faPlus;
  faFile = faFile;

  currentUser!: CurrentUser;

  constructor(private router: Router, private userState: StateService) {}

  public uploadFile() {
    this.router.navigate(['upload-file']);
  }

  ngOnInit(): void {
    // this.currentUser = this.userState.getCurrentUser();
    let usernameLC = localStorage.getItem('username') + '';
    let emailLC = localStorage.getItem('email') + '';

    this.currentUser = { username: usernameLC, email: emailLC, token: '' };

    console.log(this.currentUser);
  }

  reload() {
    setTimeout(() => {
      window.location.reload();
    }, 400);
  }
}
