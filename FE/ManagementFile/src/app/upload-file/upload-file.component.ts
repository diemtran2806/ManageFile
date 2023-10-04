import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, ViewChild } from '@angular/core';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.scss']
})
export class UploadFileComponent {
  
  @ViewChild('fileInput', { static: true }) fileInput!: ElementRef;
  // selectedFiles: File[] = [];

  selectedFile: File | null = null;

  constructor(private http: HttpClient) { }

  chooseFile() {
    this.fileInput.nativeElement.click();
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];
  }

  uploadFile(): void {
    // if (this.selectedFile) {
    //   const formData = new FormData();
    //   formData.append('file', this.selectedFile);

    //   this.http.post('your-api-endpoint/upload', formData).subscribe(response => {
    //     // Handle the response from the server.
    //   });
    // }
  }
}
