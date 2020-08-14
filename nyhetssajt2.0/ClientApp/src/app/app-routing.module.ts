import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NyhetsfeedComponent } from './nyhetsfeed/nyhetsfeed.component';
import { NyhetspuffComponent } from './nyhetspuff/nyhetspuff.component';
import { NyhetspuffAddEditComponent } from './nyhetspuff-add-edit/nyhetspuff-add-edit.component';

const routes: Routes = [
  { path: '', component: NyhetspuffComponent, pathMatch: 'full'},
  { path: 'nyhetspuff/:id', component: NyhetspuffComponent },
  { path: 'add', component: NyhetspuffAddEditComponent },
  { path: 'nyhetspuff/edit/:id', component: NyhetspuffAddEditComponent },
  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
