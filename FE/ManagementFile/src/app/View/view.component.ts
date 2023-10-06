import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ServerHttpService } from '../Services/server-http.service';

@Component({
  selector: 'view',
  templateUrl: './view.component.html',
  styleUrls: ['./view.component.css'],
})
export class View {
  title = 'ManagementFile';
  add: boolean = false;
  listFolder: any;
  listFile: any;
  listSuggestionFile: any = [];
  tam: any;
  detailFolder: any;
  folder: any = [];
  type: any = [];
  types: any = [];
  typess: any = [];
  filter = false;
  addd = true;
  listFiles: any;
  date: any;
  chon = false;
  mangadd: any = [];
  mangaddd: any = [];
  timeatt:any
  view:any={}
  name = false
  change = true
  constructor(private _http: HttpClient, private d: ServerHttpService) {}
  ngOnInit(): void {
    this._http.get('http://localhost:3000/folder').subscribe((data) => {
      this.listFolder = data;
    });

    this._http.get('http://localhost:3000/file').subscribe((data) => {
      this.listFile = data;
      this.listFiles = this.listFile;
      for (let i = 0; i < this.listFile.length; i++) {
        this.listSuggestionFile[i] = {
          ngay: this.listFile[i].ngay,
          ten: this.listFile[i].filename,
        };
        this.mangadd.push(false);
        this.mangaddd.push(true);

        for (let i = 0; i < this.listSuggestionFile.length - 1; i++) {
          for (let j = i + 1; j < this.listSuggestionFile.length; j++) {
            if (
              this.listSuggestionFile[i].ngay < this.listSuggestionFile[j].ngay
            ) {
              this.tam = this.listSuggestionFile[j];
              this.listSuggestionFile[j] = this.listSuggestionFile[i];
              this.listSuggestionFile[i] = this.tam;
            }
          }
        }
      }
      console.log(this.mangadd);
    });

    this._http.get('http://localhost:3000/detailFolder').subscribe((data) => {
      this.detailFolder = data;
    });
  }

  more(index: any) {
    if (this.mangadd[index] == false) {
      this.mangadd[index] = true;
    } else {
      this.mangadd[index] = false;
    }
  }
  viewfolder(i: any) {
    this.folder = [];
    this.d.detailFile = [];
    console.log(this.detailFolder[0].folderId);

    for (let j = 0; j < this.detailFolder.length; j++) {
      if (this.detailFolder[j].folderId == i) {
        this.folder.push(this.detailFolder[j].fileId);
      }
    }

    for (let k = 0; k < this.listFile.length; k++) {
      for (let m = 0; m < this.folder.length; m++) {
        if (this.listFile[k].id == this.folder[m]) {
          this.d.detailFile.push(this.listFile[k]);
        }
      }
    }
  }
  sort(value: any) {
    this.types = [];
    this.filter = true;
    this.addd = false;

    if (value == 1) {
      this.type = 'word';
      this.chon = true;
    } else if (value == 2) {
      this.type = 'pdf';
      this.chon = true;
    } else if (value == 3) {
      this.type = 'excel';
      this.chon = true;
    } else if (value == 0) {
      this.filter = false;
      this.addd = true;
      this.types = [];
    }

    for (let i = 0; i < this.listFile.length; i++) {
      console.log(this.listFile[i].filename);

      if (this.listFile[i].filename.includes(this.type)) {
        this.types.push(this.listFile[i]);
      }
    }
    this.listFiles = this.types;
    console.log(this.types);
  }
  sortday(value: any) {
    this.filter = true;
    this.addd = false;
    if (value == 1) {
      const currentDate = new Date();
      currentDate.setDate(currentDate.getDate());
      const year = currentDate.getFullYear();
      let month = '' + (currentDate.getMonth() + 1);
      let day = '' + currentDate.getDate();
      if (month.length < 2) {
        month = '0' + month;
      }
      if (day.length < 2) {
        day = '0' + day;
      }
      this.date = [year, month, day].join('-');
      console.log(this.date);
    } else if (value == 2) {
      const currentDate = new Date();
      currentDate.setDate(currentDate.getDate() - 1);
      const year = currentDate.getFullYear();
      let month = '' + (currentDate.getMonth() + 1);
      let day = '' + currentDate.getDate();
      if (month.length < 2) {
        month = '0' + month;
      }
      if (day.length < 2) {
        day = '0' + day;
      }
      this.date = [year, month, day].join('-');
      console.log(this.date);
    } else if (value == 3) {
      const currentDate = new Date();
      currentDate.setDate(currentDate.getDate() - 7);
      const year = currentDate.getFullYear();
      let month = '' + (currentDate.getMonth() + 1);
      let day = '' + currentDate.getDate();
      this.date = [year, month, day].join('-');
      if (month.length < 2) {
        month = '0' + month;
      }
      if (day.length < 2) {
        day = '0' + day;
      }
      console.log(this.date);
    } else if (value == 0) {
      this.filter = false;
      this.addd = true;
    }

    if (!this.chon) {
      this.types = [];
      for (let i = 0; i < this.listFile.length; i++) {
        console.log(this.listFile[i].ngay);
        console.log(typeof this.listFile[i].ngay);

        if (this.listFile[i].ngay === this.date) {
          this.types.push(this.listFile[i]);
        }
      }
      this.listFiles = this.types;
      console.log(this.types);
    }

    if (this.chon) {
      this.typess = [];
      console.log(this.types);
      for (let i = 0; i < this.types.length; i++) {
        if (this.types[i].ngay === this.date) {
          this.typess.push(this.types[i]);
        }
      }
      this.listFiles = this.typess;
      console.log(this.listFiles);

      console.log(this.typess);
    }
  }
  lastview(value:any)
  {
    this.view={}
    console.log(value);
    
    const currentDate = new Date();
    currentDate.setDate(currentDate.getDate());
    const year = currentDate.getFullYear();
    let month = '' + (currentDate.getMonth() + 1);
    let day = '' + currentDate.getDate();
    if (month.length < 2) {
      month = '0' + month;
    }
    if (day.length < 2) {
      day = '0' + day;
    }

    
    this.timeatt = {
      "timeat":[year, month, day].join('-')
    }

    this.listFile[value-1].timeat=[year, month, day].join('-')

    console.log(this.timeatt);

    this._http.patch(`http://localhost:3000/file/`+value,this.timeatt).subscribe((data) => {
      this.listFile[value-1]=data
    });
    console.log(this.listFile);


    this.view={
      "view": this.listFile[value-1].view + 1
    }

    this.listFile[value-1].view=this.listFile[value-1].view+1

    console.log(this.view);
    

    this._http.patch(`http://localhost:3000/file/`+value,this.view).subscribe((data) => {
      this.listFile[value-1]=data
      console.log(this.listFile);
      
    });    
  }
  addfolder()
  {
    const value={
        "foldername": "Folder 6",
        "soSP": 351,
        "username": "thien"
    }
    this._http.post(`http://localhost:3000/folder/`,value ).subscribe((data) => {
      console.log(this.listFile);
      
    });    
  }
  changename(value:any,index:any)
  {
    // this.name=true;
    // this.change=false
    
    if (this.mangadd[index] == false) {
      this.mangadd[index] = true;
    } else {
      this.mangadd[index] = false;
    }

    if (this.mangaddd[index] == true) {
      this.mangaddd[index] = false;
    } else {
      this.mangaddd[index] = true;
    }
  }
  submitname(index:any,value:any)
  {
    console.log(value);
    
    const name={
      "filename": value
    }
    this.listFile[index-1].filename=value
    this._http.patch(`http://localhost:3000/file/`+index,name).subscribe((data) => {
      this.listFile[value-1]=data
      console.log(this.listFile);
      
    }); 
    if (this.mangadd[index-1] == true) {
      this.mangadd[index-1] = false;
    } else {
      this.mangadd[index-1] = true;
    }

    if (this.mangaddd[index-1] == false) {
      this.mangaddd[index-1] = true;
    } else {
      this.mangaddd[index-1] = false;
    }   
  }
}
