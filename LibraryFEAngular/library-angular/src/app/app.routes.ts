import { Routes } from '@angular/router';
import { LibraryComponent } from './components/library/library.component';
import { AddBookComponent } from './components/add-book/add-book.component';
import{UpdateBookComponent} from './components/update-book/update-book.component';

export const routes: Routes = [
  { path: '', component: LibraryComponent },
  { path: 'add-book', component: AddBookComponent },
  {path: 'update-book/:bookId', component: UpdateBookComponent}
];