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
  bookToEdit: any = {};
  genres = Object.values(BookGenre);
  

  ngOnInit(): void {
    const bookId = this.route.snapshot.paramMap.get('bookId');
    if (bookId) {
      this.apiService.getBookById(bookId).subscribe({
        next: response => {
          this.bookToEdit = response;  
          console.log('Fetched book data:', response);  
          this.populateForm(response);
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
    const confirmUpdate = window.confirm('Are you sure you want to update this book?');
    if (!confirmUpdate) {
      return; 
    }

    const bookId = this.route.snapshot.paramMap.get('bookId');
    if (bookId) {
      this.bookToEdit.bookId = String(bookId);  
    }
  
    if (!this.bookToEdit || !this.bookToEdit.bookId) {
      console.error('Book or bookId is missing');
      return;
    }
  
    this.apiService.updateBook(this.bookToEdit.bookId, this.bookToEdit).subscribe({
      next: response => {
        console.log('Book updated successfully', response);
        this.router.navigate(['/']);
      },
      error: err => {
        console.error('Error updating book', err);
      }
    });
  }

  populateForm(book: Book){
    this.bookToEdit= book;
    this.cdr.detectChanges();
  }

  goBack(): void {
    this.router.navigate(['/']);
  }
}