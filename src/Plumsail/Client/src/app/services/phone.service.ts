import { Inject, Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { map } from 'rxjs/operators';

import { Phone } from '../models/phone.model';

export interface IPhoneService {
    getPhones(title?: string);
    addPhone(phone: Phone);
}

@Injectable()
export class PhoneService implements IPhoneService {
    constructor(
        private _http: HttpClient,
        
        @Inject('BASE_URL') 
        private _baseUrl: string) {

    }

  getPhones(title?: string) {
    if (title == null)
      return this._http.get<Phone[]>(this._getUrl());

      const params = new HttpParams().append('title', title);
    
      return this._http.get<Phone[]>(this._getUrl(), { params: params });
    }    
    
    addPhone(phone: Phone) {
        return this._http.post<Phone>(this._getUrl(), phone);
    }

    private _getUrl() {
        return `${this._baseUrl}api/v1/phones`;
    }
}
