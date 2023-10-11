import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';
import { UploadFileComponent } from './upload-file/upload-file.component';
import { View } from './View/view.component';
import { ViewDetailFileComponent } from './components/view-detail-file/view-detail-file.component';

const routes: Routes = [
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: '',
    component: MainLayoutComponent,
    children: [
      { path: 'upload-file', component: UploadFileComponent },
      { path: 'view/:id', component: ViewDetailFileComponent },
      { path: 'view', component: View },

      { path: '', redirectTo: '/view', pathMatch: 'full' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
