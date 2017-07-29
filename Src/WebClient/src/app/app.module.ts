import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { TabsModule, AccordionModule } from 'ngx-bootstrap';

import { AppComponent } from './app.component';

import { AppRoutingModule } from './app-routing.module';
import { SideNavbarComponent } from './block/side-navbar/side-navbar.component';
import { ConfigService } from './service/config.service';
import { NovelListComponent } from './novel-list/novel-list.component';

@NgModule({
  declarations: [
    AppComponent,
    SideNavbarComponent,
    NovelListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    TabsModule.forRoot(),
    AccordionModule.forRoot()
  ],
  providers: [ConfigService],
  bootstrap: [AppComponent]
})
export class AppModule { }
