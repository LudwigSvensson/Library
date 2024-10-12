import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { RouterOutlet, RouterLink, RouterLinkActive, Route } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Book} from '../../../models/book.models';
import { Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AddBookComponent } from "../add-book/add-book.component";
import { UpdateBookComponent } from '../update-book/update-book.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-library',
  standalone: true,
  imports: [RouterOutlet, CommonModule, FormsModule, AddBookComponent, UpdateBookComponent,RouterLink, RouterLinkActive],
  providers: [ApiService],
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent implements OnInit {

  constructor(@Inject(ApiService) private apiService: ApiService, private router: Router) { }
    books: Book[] = [];
  ngOnInit(): void {
  this.apiService.getBooks().subscribe({
    next: response => {
      console.log('API response:', response);
      this.books = response as Book[];
    },
    error: error => {
      console.error('Error', error);
    }
  });
  }
  onEditBook(book: any) {
    // Skicka hela bokobjektet via Router's state
    this.router.navigate(['/update-book', book.bookId]);
  }

  deleteBook(bookId: string): void {
    this.apiService.deleteBook(bookId.toString()).subscribe({
      next: () => {
        this.books = this.books.filter(book => book.bookId !== bookId);
      },
      error: error => {
        console.error('Error deleting book', error);
      }
    });
  } 
  
}

