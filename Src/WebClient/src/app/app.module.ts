import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';

import { TabsModule, AccordionModule, TooltipModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';

import { SideNavbarComponent } from './block/side-navbar/side-navbar.component';

import { ConfigService } from './service/config.service';
import { HttpService } from './service/http.service';
import { SpiderModule } from './spider/spider.module';

@NgModule({
  declarations: [
    AppComponent,
    SideNavbarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    JsonpModule,

    SpiderModule,

    AppRoutingModule,
    TabsModule.forRoot(),
    AccordionModule.forRoot(),
    TooltipModule.forRoot()
  ],
  providers: [
    ConfigService,
    HttpService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
