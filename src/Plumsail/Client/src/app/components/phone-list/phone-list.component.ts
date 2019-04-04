import { Component, Inject, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

import { IPhoneService } from '../../services/phone.service';
import { Phone } from '../../models/phone.model';
import { HomePage, SearchingDebounceSeconds } from '../../constants';

@Component({
  selector: 'phone-list',
  templateUrl: './phone-list.component.html'
})
export class PhoneListComponent implements OnInit {
  phones: Phone[];
  searchControl: FormControl;

  constructor(
    private _router: Router,
    @Inject('PhoneService')
    private _phone: IPhoneService) {
    this.searchControl = new FormControl();
  }

  ngOnInit(): void {
    this.searchControl
      .valueChanges
      .pipe(
        debounceTime(SearchingDebounceSeconds * 1000),
        distinctUntilChanged())
      .subscribe(v => this._getPhones(v));

    if (this.phones == null)
      this._getPhones();
  }

  goHome() {
    this._router.navigate([HomePage]);
  }

  private _getPhones(title?: string) {
    this._phone.getPhones(title).subscribe(res => this.phones = res, this._failed);
  }

  private _failed(error) {
    console.error(error);
  }
}
