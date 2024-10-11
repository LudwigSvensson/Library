import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../../models/book.models';
import { map } from 'rxjs/operators';
import { ApiResponse } from '../../models/apiResponse.models';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  private baseUrl = 'https://localhost:7268'; // API UR

  constructor(private http: HttpClient) { }

  // Example method to get data
  getBooks(): Observable<Book[]> {
    return this.http.get<ApiResponse>(this.baseUrl + '/api/books').pipe(
      map(response => response.result)
    );
  }

  addBook(book: Book): Observable<Book> {
    return this.http.post<Book>(this.baseUrl + '/api/book', book);
  }

  updateBook(book: Book): Observable<Book> {
    return this.http.put<Book>(`${this.baseUrl}/api/book/${book.bookId}`, book);
  }

  deleteBook(bookId: string): Observable<void> {
    return this.http.delete<void>(`${this.baseUrl}/api/book/${bookId}`);
  }

  getBookById(bookId: string): Observable<Book> {

    return this.http.get<Book>(`/api/books/${bookId}`);

  }
}
