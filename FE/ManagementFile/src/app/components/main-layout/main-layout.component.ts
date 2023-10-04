import { Component } from '@angular/core';
import {
  faGear,
  faMagnifyingGlass,
  faPlus,
  faFile,
} from '@fortawesome/free-solid-svg-icons';

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
}
