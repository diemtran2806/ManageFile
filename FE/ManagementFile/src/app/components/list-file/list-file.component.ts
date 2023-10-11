import { Component } from '@angular/core';
import { ServerHttpService } from 'src/app/Services/server-http.service';
import { File } from 'src/app/interfaces/file';
import { MenuItem } from 'primeng/api';
import { Router } from '@angular/router';
import { DialogService, DynamicDialogRef } from 'primeng/dynamicdialog';
import { MessageService } from 'primeng/api';
import { ShareFileComponent } from '../share-file/share-file.component';

@Component({
  selector: 'app-list-file',
  templateUrl: './list-file.component.html',
  styleUrls: ['./list-file.component.scss'],
  providers: [DialogService, MessageService],
})
export class ListFileComponent {
  files!: File[];
  items: MenuItem[] | undefined;
  fileId!: number;
  ref: DynamicDialogRef | undefined;

  constructor(
    private api: ServerHttpService,
    private router: Router,
    public dialogService: DialogService,
    public messageService: MessageService
  ) {}

  ngOnInit() {
    this.api
      .getAllFile()
      .then((response) => {
        this.files = response.data;
      })
      .catch((error) => {
        console.log(error);
      });

    this.items = [
      {
        icon: 'pi pi-fw pi-ellipsis-v',
        items: [
          {
            label: 'View',
            icon: 'pi pi-fw pi-eye',
            command: () => this.router.navigate([`view/${this.fileId}`]),
          },
          {
            label: 'Share',
            icon: 'pi pi-fw pi-share-alt',
            command: () => this.show(),
          },
          {
            label: 'Rename',
            icon: 'pi pi-fw pi-eye',
          },
          {
            label: 'Delete',
            icon: 'pi pi-fw pi-delete-left',
            command: () => this.deleteFileById(),
          },
        ],
      },
    ];
  }

  show() {
    this.ref = this.dialogService.open(ShareFileComponent, {
      header: 'Share',
      width: '40%',
      contentStyle: { overflow: 'auto' },
      baseZIndex: 10000,
      maximizable: true,
    });
    // product: Product
    this.ref.onClose.subscribe(() => {
      // if (product) {
      //   this.messageService.add({
      //     severity: 'info',
      //     summary: 'Product Selected',
      //     detail: product.name,
      //   });
      // }
    });
  }

  getId(fileId: number) {
    this.fileId = fileId;
  }

  deleteFileById() {
    this.api
      .deleteFile(this.fileId)
      .then(() => {
        window.location.reload();
      })
      .catch((error) => {
        console.log(error);
      });
  }
}
