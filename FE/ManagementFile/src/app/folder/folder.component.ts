import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ServerHttpService } from '../Services/server-http.service';

@Component({
  selector: 'folder',
  templateUrl: './folder.component.html',
  styleUrls: ['./folder.component.css']
})
export class Folder {
  listFolder:any
  constructor(private _http:HttpClient, private d: ServerHttpService) { }
  
  ngOnInit(): void { 
    // this._http.get('http://localhost:3000/folder').subscribe(data => {
    //    this.listFolder=data;    
    //  });

    //  this._http.get('http://localhost:3000/file').subscribe(data => {
      
    //  });
    this.listFolder=this.d.detailFile
    console.log(this.listFolder);
    
}
}