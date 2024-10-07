import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiService } from './services/api.service'; 
import { LibraryComponent } from './components/library/library.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, LibraryComponent],
  providers: [ApiService],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  title = 'library-angular';
  }

