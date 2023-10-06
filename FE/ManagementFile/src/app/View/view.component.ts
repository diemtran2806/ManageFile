import { Component, OnInit } from '@angular/core';
import { ServerHttpService } from '../Services/server-http.service';
import { MenuItem } from 'primeng/api';

interface FileObject {
  id: number;
  fileName: string;
  author: string;
  uploadDate: string;
}

@Component({
  selector: 'view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css'],
})
export class View implements OnInit {
  title = 'ManagementFile';

  fileUpload: FileObject[] = [];
  fileDeleteId!: number;
  items: MenuItem[] | undefined;

  constructor(private api: ServerHttpService) {}

  ngOnInit(): void {
    console.log(this.fileDeleteId);
    this.api
      .getAllFile()
      .then((response) => {
        console.log("res data",response.data);
        this.fileUpload = response.data;
      })
      .catch((error) => {
        console.log(error);
      });
  }

  getId(fileId: number) {
    this.fileDeleteId = fileId;
  }

  deleteFileById() {
    this.api
      .deleteFile(this.fileDeleteId)
      .then(() => {
        window.location.reload();
      })
      .catch((error) => {
        console.log(error);
      });
  }
}
