import { Component, ElementRef, ViewChild } from '@angular/core';
import { ServerHttpService } from '../Services/server-http.service';
import { ActivatedRoute, Router } from '@angular/router';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-upload-file',
  templateUrl: './upload-file.component.html',
  styleUrls: ['./upload-file.component.scss'],
})
export class UploadFileComponent {
  @ViewChild('fileInput', { static: true }) fileInput!: ElementRef;
  // selectedFiles: File[] = [];

  selectedFile: File | null = null;
  faTrash = faTrash;

  constructor(
    private serverHttp: ServerHttpService,
    private router: Router,
    private route: ActivatedRoute,
    private toastService: NgToastService
  ) {}

  chooseFile() {
    this.fileInput.nativeElement.click();
  }

  onFileSelected(event: any): void {
    this.selectedFile = event.target.files[0];
  }

  removeFile(): void {
    this.selectedFile = null;
  }

  uploadFile(): void {
    if (this.selectedFile) {
      const formData = new FormData();
      formData.append('file', this.selectedFile);
      formData.append('author', localStorage.getItem('username') || '');
      // this.serverHttp.uploadFileToServer(formData)
      //   .subscribe(response => {
      //     // Xử lý phản hồi từ máy chủ (nếu cần)
      //     console.log('Upload successfully!', response);
      //   });
      this.serverHttp
        .uploadFileToServer(formData)
        .then((response) => {
          this.toastService.success({
            detail: 'Upload successfully!',
            summary: 'A file have already uploaded!',
            duration: 5000,
            position: 'topRight',
          });
          this.router.navigate(['view']);
        })
        .catch((error) => {
          this.toastService.error({
            detail: 'Upload failed!',
            summary: 'A file have already uploaded!',
            duration: 5000,
            position: 'topRight',
          });
        });
    } else {
      this.toastService.warning({
        detail: 'Please choose a file!',
        summary: 'A file have already uploaded!',
        duration: 5000,
        position: 'topRight',
      });
    }
  }
}
