import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { ApiService } from './api.service';

describe('ApiService', () => {
  let service: ApiService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [ApiService]
    });
    service = TestBed.inject(ApiService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should fetch books as an Observable', () => {
    const dummyBooks: any[] = [
      { id: 1, title: 'Book 1', author: 'Author 1' },
      { id: 2, title: 'Book 2', author: 'Author 2' }
    ];

    service.getBooks().subscribe(books => {
      expect(books.length).toBe(2);
      expect(books).toEqual(dummyBooks);
    });

    const req = httpMock.expectOne(`${service['baseUrl']}/api/book`);
    expect(req.request.method).toBe('GET');
    req.flush(dummyBooks);
  });

  it('should post a book and return it', () => {
    const newBook: any = { id: 3, title: 'Book 3', author: 'Author 3' };

    service.postBook(newBook).subscribe(book => {
      expect(book).toEqual(newBook);
    });

    const req = httpMock.expectOne(`${service['baseUrl']}/api/book`);
    expect(req.request.method).toBe('POST');
    req.flush(newBook);
  });
});