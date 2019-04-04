import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';

import { AddNewPhone, PhoneList } from '../../constants';

@Component({
  selector: 'home',
  templateUrl: './home.component.html'
})
export class HomeComponent {

  constructor(
    private _router: Router
  ){

  }

  addPhone() {
    this._router.navigate([AddNewPhone]);
  }

  showPhones() {
    this._router.navigate([PhoneList]);
  }
}
