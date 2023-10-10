import { Component, OnInit } from '@angular/core';
import * as XLSX from 'xlsx';
import { HttpClient } from '@angular/common/http';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { ActivatedRoute } from '@angular/router';

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
  data: any[] = [];
  docContent!: string;
  typeFile!: string;
  fileId!: string;
  fileUpload!: FileObject;
  fileName!: string;
  fileView!: string;

  constructor(
    private http: HttpClient,
    private api: ServerHttpService,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const excelFilePath = '../../../assets/text.docx';

    this.route.params.subscribe((params) => {
      this.fileId = params['id'];
    });

    this.api
      .getFileById(this.fileId)
      .then((res) => {
        this.fileUpload = res.data;
        this.fileName = this.fileUpload.fileName;
        // console.log(this.fileName);
      })
      .catch((error) => {
        console.log(error);
      });

    setTimeout(() => {
      if (
        this.getFileExtension(this.fileName) === 'png' ||
        this.getFileExtension(this.fileName) === 'jpg'
      ) {
        this.typeFile = this.getFileExtension(this.fileName);
        this.fileView = `https://localhost:5050/api/file/view/${this.fileId}`;
        console.log(this.fileView);
        console.log(this.typeFile);
      }
    }, 500);

    if (this.typeFile === 'xlsx') {
      this.http
        .get(excelFilePath, { responseType: 'arraybuffer' })
        .subscribe((response: ArrayBuffer) => {
          const binarystr = new Uint8Array(response);
          const workbook = XLSX.read(binarystr, { type: 'array' });
          const first_sheet_name = workbook.SheetNames[0];
          const worksheet = workbook.Sheets[first_sheet_name];

          this.data = XLSX.utils.sheet_to_json(worksheet, { raw: true });
        });
    } else if (this.typeFile === 'docx' || this.typeFile === 'doc') {
    }
  }

  getFileExtension(fileName: string): string {
    const parts = fileName.split('.');
    const fileExtension = parts[parts.length - 1];
    return fileExtension;
  }
}
