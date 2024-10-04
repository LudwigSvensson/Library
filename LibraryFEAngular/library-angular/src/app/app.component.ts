import { Component } from '@angular/core';
import { Book } from './Models/Book'; 
import { ApiService } from './services/api.service'; 


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})


export class AppComponent {
  title = 'library-angular';
  books: Book[] = [];
  book: Book = {
    bookId: '',
    title: '',
    author: '',
    bookGenre: '',
    realeseYear: ''
  }


  constructor(private apiService: ApiService) { }

  ngOnInit() {
    this.getAllBooks();
  }

  getAllBooks() {
    this.apiService.getBooks().subscribe((data: Book[]) => {
      this.books = data;
    });
  }
}
