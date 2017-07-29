import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NovelListComponent } from './novel-list/novel-list.component';

const appRoutes: Routes = [
    {
        path: 'spider/novel',
        component: NovelListComponent
    },
    {
        path: '',
        redirectTo: 'spider/novel',
        pathMatch: 'full'
    },
];

@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes
        )
    ],
    exports: [
        RouterModule
    ],
    providers: [
    ]
})
export class AppRoutingModule { }