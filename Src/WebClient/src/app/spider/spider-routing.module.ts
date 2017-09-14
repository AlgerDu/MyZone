import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NovelListComponent } from './novel/list/novel-list.component';

@NgModule({
    imports: [RouterModule.forChild([
        { path: '', redirectTo: 'novel', pathMatch: 'full' },
        { path: 'novel', component: NovelListComponent }
    ])],
    exports: [RouterModule]
})
export class SpiderRoutingModule { }