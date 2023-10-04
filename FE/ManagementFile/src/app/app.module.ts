import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';

import { HttpClientModule } from '@angular/common/http';
import { UploadFileComponent } from './upload-file/upload-file.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    MainLayoutComponent,
    UploadFileComponent
  ],
  imports: [BrowserModule, AppRoutingModule, FontAwesomeModule, HttpClientModule],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
