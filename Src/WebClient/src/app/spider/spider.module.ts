import { NgModule } from '@angular/core';
import { SpiderRoutingModule } from './spider-routing.module';
import { NovelListComponent } from './novel/list/novel-list.component';
import { NovelManagementService } from './novel/novel-management.srvice';
import { BrowserModule } from '@angular/platform-browser';

@NgModule({
    imports: [
        BrowserModule,
        SpiderRoutingModule
    ],
    declarations: [
        NovelListComponent
    ],
    providers: [
        NovelManagementService
    ]
})
export class SpiderModule { }