import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Book } from '../../../models/book.models';

@Component({
  selector: 'app-library',
  standalone: true,
  imports: [RouterOutlet, CommonModule],
  providers: [ApiService],
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent implements OnInit {

  constructor(private apiService: ApiService) { }
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
}
