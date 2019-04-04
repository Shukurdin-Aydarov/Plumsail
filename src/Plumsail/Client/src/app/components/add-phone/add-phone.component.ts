import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { Phone } from 'src/app/models/phone.model';
import { IPhoneService } from '../../services/phone.service';
import { DateValidator } from '../../validators/date.validator';
import { MinDate, DateFormat, HomePage } from '../../constants';

@Component({
    selector: 'add-phone',
    templateUrl: './add-phone.component.html'
})
export class AddPhoneComponent {
    form: FormGroup;
    memories = [2, 4, 8, 16];
    
    constructor(
        formBuilder: FormBuilder, 
        
        @Inject('PhoneService')
        private _phoneService: IPhoneService,
        private _router: Router) {
        
        this.form = this._buildForm(formBuilder);
    }

    private _buildForm(formBuilder: FormBuilder) {
        return formBuilder.group({
            title: ['', Validators.required],
            price: ['', [Validators.required, Validators.min(1)]],
            memory: ['', Validators.required],
            productionDate: ['', [Validators.required, DateValidator.min(MinDate, DateFormat)]],
            nfc:[false],
            color:['', Validators.required]
        });
    }

    submit() {
        const values = this.form.value;
        const phone = new Phone();

        phone.title = values.title;
        phone.price = values.price;
        phone.memory = values.memory;
        phone.productionDate = values.productionDate;
        phone.nfc = values.nfc;
        phone.color = values.color;

        this._phoneService.addPhone(phone).subscribe(this._succes, this._failed);
    }

    goHome() {
      this._router.navigate([HomePage]);
    }

    private _succes = (phone: Phone) => {
        this._router.navigate([HomePage]);
    }

    private _failed = (error) => {
        console.error(error);        
    }
}
