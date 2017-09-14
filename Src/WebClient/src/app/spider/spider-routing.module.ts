import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NovelListComponent } from './novel/list/novel-list.component';

const routes: Routes = [
    { path: '', redirectTo: 'novel', pathMatch: 'full' },
    { path: 'novel', component: NovelListComponent }
]

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class SpiderRoutingModule { }