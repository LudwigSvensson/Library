import { Component } from '@angular/core';
import { RouterOutlet, RouterLink, RouterLinkActive } from '@angular/router';
import { ApiService } from './services/api.service'; 
import { LibraryComponent } from './components/library/library.component';
import { FormsModule } from '@angular/forms';
import { AddBookComponent } from './components/add-book/add-book.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, LibraryComponent, FormsModule, AddBookComponent, RouterLink, RouterLinkActive],
  providers: [ApiService],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'library-angular';
}
