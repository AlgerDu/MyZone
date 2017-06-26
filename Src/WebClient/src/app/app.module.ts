import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { TabsModule, AccordionModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { SideNavbarComponent } from './block/side-navbar/side-navbar.component';

@NgModule({
  declarations: [
    AppComponent,
    SideNavbarComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TabsModule.forRoot(),
    AccordionModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
