import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NovelListComponent } from './novel-list/novel-list.component';
import { NovelEditComponent } from './novel-edit/novel-edit.component';

const appRoutes: Routes = [
    {
        path: 'spider/novel',
        component: NovelListComponent
    },
    {
        path: 'spider/novel/:author/:name/edit',
        component: NovelEditComponent
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