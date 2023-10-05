import { Injectable } from '@angular/core';
import axios from 'axios';

@Injectable({
  providedIn: 'root',
})
export class ServerHttpService {
  constructor() {}

  getAllFile() {
    return axios.get('https://localhost:5050/api/file');
  }

  deleteFile(id: number) {
    console.log(id);
    return axios.delete(`https://localhost:5050/api/file/${id}`);
  }
}
