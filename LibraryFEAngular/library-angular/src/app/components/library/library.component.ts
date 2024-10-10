import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { CommonModule } from '@angular/common';
import { Book} from '../../../models/book.models';
import { Inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { error } from 'console';
import { AddBookComponent } from "../add-book/add-book.component";

@Component({
  selector: 'app-library',
  standalone: true,
  imports: [RouterOutlet, CommonModule, FormsModule, AddBookComponent],
  providers: [ApiService],
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.css']
})
export class LibraryComponent implements OnInit {

  constructor(@Inject(ApiService) private apiService: ApiService) { }
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

