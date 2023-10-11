import { Injectable } from '@angular/core';
import { CurrentUser } from 'src/app/interfaces/user';

@Injectable({
  providedIn: 'root',
})
export class StateService {
  private currentUser!: CurrentUser;

  getCurrentUser() {
    return this.currentUser;
  }

  setCurrentUser(user: CurrentUser) {
    this.currentUser = user;
  }
}
