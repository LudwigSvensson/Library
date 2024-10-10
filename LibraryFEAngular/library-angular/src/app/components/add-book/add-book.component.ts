import { Component } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Book, BookGenre } from '../../../models/book.models';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-add-book',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-book.component.html',
  styleUrl: './add-book.component.css'
})
export class AddBookComponent {

  constructor(private apiService: ApiService, private router: Router) { }
  newBook: Book = { bookId: '', title: '', author: '', bookGenre: BookGenre.Biografi, realeseYear: new Date() };
  books: Book[] = [];
  genres = Object.values(BookGenre);

  createBook(): Book {
    console.log('Create book:', this.newBook);
    this.apiService.addBook(this.newBook).subscribe({
      next: response => {
        console.log('Book created:', response);
        this.router.navigate(['/']);
      },
      error: error => {
        console.error('Error creating book:', error);
      }
    });
    return this.newBook;
  }
}
