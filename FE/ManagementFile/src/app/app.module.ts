import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { FormsModule } from '@angular/forms';
import { NgToastModule } from 'ng-angular-popup';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { MainLayoutComponent } from './components/main-layout/main-layout.component';

import { HttpClientModule } from '@angular/common/http';
import { UploadFileComponent } from './upload-file/upload-file.component';
import { View } from './View/view.component';
import { ViewDetailFileComponent } from './components/view-detail-file/view-detail-file.component';
import { ObjectToArrayPipe } from './components/object-to-array.pipe';
import '../assets/docx-preview.js';
import { NgxDocViewerModule } from 'ngx-doc-viewer';
import { TableModule } from 'primeng/table';
import { MenubarModule } from 'primeng/menubar';
import { ListFileComponent } from './components/list-file/list-file.component';
import { PdfViewerModule } from 'ng2-pdf-viewer';
import { ShareFileComponent } from './components/share-file/share-file.component';
import { DynamicDialogModule } from 'primeng/dynamicdialog';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    MainLayoutComponent,
    UploadFileComponent,
    View,
    ViewDetailFileComponent,
    ObjectToArrayPipe,
    ListFileComponent,
    ShareFileComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FontAwesomeModule,
    HttpClientModule,
    FormsModule,
    NgToastModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    NgxDocViewerModule,
    TableModule,
    MenubarModule,
    PdfViewerModule,
    DynamicDialogModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
