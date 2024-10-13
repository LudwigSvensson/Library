import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Router, ActivatedRoute } from '@angular/router';
import { Book, BookGenre } from '../../../models/book.models';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-update-book',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './update-book.component.html',
  styleUrls: ['./update-book.component.css']
})
export class UpdateBookComponent implements OnInit {

  constructor(private apiService: ApiService, private router: Router, private route: ActivatedRoute, private cdr: ChangeDetectorRef) { }
  book: Book = { bookId: '', title: '', author: '', bookGenre: BookGenre.Biografi, realeseYear: new Date() };
  genres = Object.values(BookGenre);
  

  ngOnInit(): void {
    const bookId = this.route.snapshot.paramMap.get('bookId');
    if (bookId) {
      this.apiService.getBookById(bookId).subscribe({
        next: response => {
          this.book = response as Book;  // Se till att vi hämtar bokens data korrekt
          console.log('Fetched book data:', this.book);  // Logga bokens data
          this.cdr.detectChanges();  // Tvinga en uppdatering av formuläret
        },
        error: error => {
          console.error('Error fetching book', error);
        }
      });
    }
  }

  updateBook(bookForm: NgForm): void {
    if (bookForm.invalid) {
      Object.keys(bookForm.controls).forEach(field => {
        const control = bookForm.controls[field];
        control.markAsTouched({ onlySelf: true });
      });
      return;
    }

    // Confirm update action
    const confirmUpdate = window.confirm('Are you sure you want to update this book?');
    if (!confirmUpdate) {
      return; // Exit if the user cancels the update
    }

    // Få alltid bookId från route-parametern
    const bookId = this.route.snapshot.paramMap.get('bookId');
    if (bookId) {
      this.book.bookId = String(bookId);  // Sätt bookId explicit på objektet
    }
  
    // Kontrollera om bookId finns och att boken är redo för uppdatering
    if (!this.book || !this.book.bookId) {
      console.error('Book or bookId is missing');
      return;
    }
  
    this.apiService.updateBook(this.book.bookId, this.book).subscribe({
      next: response => {
        console.log('Book updated successfully', response);
        this.router.navigate(['/']);
      },
      error: err => {
        console.error('Error updating book', err);
      }
    });
  }

  goBack(): void {
    this.router.navigate(['/']);
  }
}