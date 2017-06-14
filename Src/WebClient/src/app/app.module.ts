import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BsDropdownModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';

@NgModule({
  imports: [
    BrowserModule,
    BsDropdownModule.forRoot()
  ],
  declarations: [
    AppComponent
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
