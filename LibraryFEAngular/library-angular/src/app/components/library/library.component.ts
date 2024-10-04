import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrl: './library.component.css'
})
export class LibraryComponent implements OnInit {

  constructor(private apiService: ApiService) { }
    data: any;
  ngOnInit(): void {
    this.apiService.getBooks().subscribe(response => {
      this.data = response;
    });
  }

}
