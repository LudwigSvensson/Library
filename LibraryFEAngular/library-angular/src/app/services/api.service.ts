import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

interface Data {
  // Define the properties of the Data interface here
  // For example:
  title: string;
  author: string;
}
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:7268'; // API UR

  constructor(private http: HttpClient) { }

  // Example method to get data
  getBooks(): Observable<any[]> {
    return this.http.get<any[]>(`${this.baseUrl}/api/books`);
  }

  // Example method to post data

  postBook(data: Data): Observable<Data> {
    return this.http.post<Data>(`${this.baseUrl}/api/book`, data);
  }
}