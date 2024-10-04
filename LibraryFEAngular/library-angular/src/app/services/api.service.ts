import { Injectable } from '@angular/core';
import { Book } from '../Models/Book';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:7268'; // API UR

  constructor(private http: HttpClient) { }

  // Example method to get data
  getBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.baseUrl}/api/books`);
  }

  // Example method to post data

    postBook(data: Book): Observable<Book> {
      return this.http.post<Book>(`${this.baseUrl}/api/book`, data);
    }
}