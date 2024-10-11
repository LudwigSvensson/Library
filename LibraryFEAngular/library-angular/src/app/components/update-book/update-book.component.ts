import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Book, BookGenre } from '../../../models/book.models';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-update-book',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent implements OnInit {

  constructor(private apiService: ApiService, private router: Router, private route: ActivatedRoute) { }
  book: Book = { bookId: '', title: '', author: '', bookGenre: BookGenre.Biografi, realeseYear: new Date() };
  genres = Object.values(BookGenre);

  ngOnInit(): void {
    const bookId = this.route.snapshot.paramMap.get('id');
    if (bookId) {
      this.apiService.getBookById(bookId).subscribe({
        next: response => {
          this.book = response;
        },
        error: error => {
          console.error('Error fetching book', error);
        }
      });
    }
  }

  updateBook(): void {
    this.apiService.updateBook(this.book).subscribe({
      next: response => {
        console.log('Book updated:', response);
        this.router.navigate(['/']);
      },
      error: error => {
        console.error('Error updating book', error);
      }
    });
  }
}