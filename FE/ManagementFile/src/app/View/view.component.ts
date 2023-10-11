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

  constructor(private api: ServerHttpService) {}

  ngOnInit(): void {}
}
