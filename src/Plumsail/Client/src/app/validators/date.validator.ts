import { AbstractControl, ValidationErrors } from '@angular/forms';
import * as moment from 'moment';

export class DateValidator {
    static min(date: string, dateFormat: string) {
        return (control: AbstractControl): ValidationErrors | null =>{
            if (control.value == null)
                return null;
        
              const actualDate = moment(control.value, dateFormat);
        
              if (!actualDate.isValid())
                return null;
        
              const minDate = moment(date);
        
              return actualDate.isAfter(minDate) ? null : {
                'date-minimum': {
                  'date-minimum': minDate.format(dateFormat),
                  'actual': actualDate.format(dateFormat)
                }
              };
        }
    }
}