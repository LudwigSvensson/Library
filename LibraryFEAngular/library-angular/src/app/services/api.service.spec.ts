import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:7268/api/book'; // API URL

  constructor(private http: HttpClient) { }

  // Example method to get data
  getData(): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/your-endpoint`);
  }

  // Example method to post data
  postData(data: any): Observable<any> {
    return this.http.post(`${this.baseUrl}/api/your-endpoint`, data);
  }
}
