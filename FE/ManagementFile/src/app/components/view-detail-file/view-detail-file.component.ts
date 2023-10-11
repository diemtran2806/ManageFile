import { Component, OnInit } from '@angular/core';

import { ServerHttpService } from 'src/app/Services/server-http.service';
import { ActivatedRoute, Router } from '@angular/router';
import { File } from 'src/app/interfaces/file';

interface FileObject {
  id: number;
  fileName: string;
  author: string;
}

@Component({
  selector: 'app-view-detail-file',
  templateUrl: './view-detail-file.component.html',
  styleUrls: ['./view-detail-file.component.scss'],
})
export class ViewDetailFileComponent implements OnInit {
  docContent!: string;
  typeFile!: string;
  fileId!: string;
  fileUpload!: File;
  fileName!: string;
  fileView!: string;

  constructor(
    private api: ServerHttpService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.fileId = params['id'];
    });

    this.api
      .getFileById(this.fileId)
      .then((res) => {
        this.fileUpload = res.data;
        this.fileName = this.fileUpload.fileName;
      })
      .catch((error) => {
        console.log(error);
      });

    setTimeout(() => {
      if (
        this.getFileExtension(this.fileName) === 'doc' ||
        this.getFileExtension(this.fileName) === 'docx'
      ) {
        window.location.href = `https://localhost:5050/api/file/view/${this.fileId}`;
      }
      this.typeFile = this.getFileExtension(this.fileName);
      this.fileView = `https://localhost:5050/api/file/view/${this.fileId}`;
    }, 500);
  }

  getFileExtension(fileName: string): string {
    const parts = fileName.split('.');
    const fileExtension = parts[parts.length - 1];
    return fileExtension;
  }
}
