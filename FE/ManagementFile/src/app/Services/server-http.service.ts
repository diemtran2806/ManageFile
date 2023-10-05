import { Injectable } from '@angular/core';
import axios from 'axios';
import {
  HttpHeaders,
  HttpClient,
  HttpErrorResponse,
} from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class ServerHttpService {
  
  private REST_API_SERVER = 'https://localhost:7096/api';
  getAllFile() {
    return axios.get(`${this.REST_API_SERVER}/file`);
  }

  deleteFile(id: number) {
    console.log(id);
    return axios.delete(`${this.REST_API_SERVER}/file/${id}`);
  }
  private httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    }),
  };

  constructor(private httpClient: HttpClient) {}

  public uploadFileToServer(data: FormData) {
    const url = `${this.REST_API_SERVER}/file`;
    // return this.httpClient
    //   .post<any>(url, data, this.httpOptions)
    //   .pipe(
    //     catchError((error) => {
    //       console.error('An error occurred:', error); // In ra lỗi cụ thể
    //       return throwError(error); // Chuyển tiếp lỗi để xử lý ở nơi khác nếu cần
    //     })
    //   );
    return axios.post(url, data, {
      headers: {
        'Content-Type': 'multipart/form-data',
      },
    })
  }

  // private handleError(error: HttpErrorResponse) {
  //   if (error.error instanceof ErrorEvent) {
  //     // A client-side or network error occurred. Handle it accordingly.
  //     console.error('An error occurred:', error.error.message);
  //   } else {
  //     // The backend returned an unsuccessful response code.
  //     // The response body may contain clues as to what went wrong,
  //     console.error(
  //       `Backend returned code ${error.status}, ` + `body was: ${error.error}`
  //     );
  //   }
  //   // return an observable with a user-facing error message
  //   return throwError('Something bad happened; please try again later.');
  // }

}
