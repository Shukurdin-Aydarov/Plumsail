import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DatePipe } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';

import { ScrollingModule } from '@angular/cdk/scrolling';

import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { AddPhoneComponent } from './components/add-phone/add-phone.component';
import { PhoneListComponent } from './components/phone-list/phone-list.component';

import { PhoneService } from './services/phone.service';
import { HomePage, AddNewPhone, PhoneList } from './constants';

const routes: Routes = [
  { path: HomePage, component: HomeComponent },
  { path: AddNewPhone, component: AddPhoneComponent },
  { path: PhoneList, component: PhoneListComponent },
  { path: '**', component: HomeComponent }
]

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddPhoneComponent,
    PhoneListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    ScrollingModule
  ],
  providers: [
    { 
      provide: 'PhoneService', 
      useClass: PhoneService
    },
    DatePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
