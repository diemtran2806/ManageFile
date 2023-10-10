import { Component } from '@angular/core';
import {
  faGear,
  faMagnifyingGlass,
  faPlus,
  faFile,
} from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';

@Component({
  selector: 'app-main-layout',
  templateUrl: './main-layout.component.html',
  styleUrls: ['./main-layout.component.scss'],
})
export class MainLayoutComponent {
  faGear = faGear;
  faSearch = faMagnifyingGlass;
  faPlus = faPlus;
  faFile = faFile;

  constructor(private router: Router) {}

  public uploadFile() {
    this.router.navigate(['upload-file']);
  }

  reload() {
    setTimeout(() => {
      window.location.reload();
    }, 400);
  }
}
