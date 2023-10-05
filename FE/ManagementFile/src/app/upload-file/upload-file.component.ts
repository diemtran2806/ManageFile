import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, ViewChild } from '@angular/core';
import { ServerHttpService } from '../Services/server-http.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.scss']
})
export class UploadFileComponent {
  
  @ViewChild('fileInput', { static: true }) fileInput!: ElementRef;
  // selectedFiles: File[] = [];

  selectedFile: File | null = null;
  constructor(
    private serverHttp: ServerHttpService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  chooseFile() {
    this.fileInput.nativeElement.click();
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];
  }

  uploadFile(): void {
    if (this.selectedFile) {
      const formData = new FormData();
      formData.append('file', this.selectedFile);
      formData.append('author', 'Diem');
      this.serverHttp.uploadFileToServer(formData)
        .subscribe(response => {
          // Xử lý phản hồi từ máy chủ (nếu cần)
          console.log('Upload successfully!', response);
        });
    }
  }
}
