import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { View } from './View/view.component';

const routes: Routes = [
  { path: 'view', component:View}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
