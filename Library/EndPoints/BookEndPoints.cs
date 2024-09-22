using AutoMapper;
using Library.Models;
using Library.Models.DTO_s;
using Library.Repositories;

namespace Library.EndPoints
{
    public static class BookEndPoints
    {
        public static void ConfigurationBookEndPoints(this WebApplication app)
        {
            app.MapGet("/api/books", GetAllBooks).
                WithName("GetBooks").
                Produces<ResponseModel>();

            app.MapGet("/api/book/{id:int}", GetBook).
                WithName("GetBook").
                Produces<ResponseModel>();

            app.MapPost("/api/book", CreateBook).
                WithName("CreateBook").
                Accepts<BookCreateDTO>("application/json").
                Produces(201).
                Produces(400);

            app.MapPut("/api/book", UpdateBook).
                WithName("UpdateBook").
                Accepts<BookUpdateDTO>("application/json").
                Produces(200).
                Produces(400);

            app.MapDelete("/api/book/{id:int}", DeleteBook).
                WithName("DeleteBook").
                Produces(204).
                Produces(400);

        }

        private async static Task<IResult> GetAllBooks(IBookRepository bookRepository)
        {
            ResponseModel response = new ResponseModel();

            response.Result = await bookRepository.GetAllAsync();
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);

        }

        private async static Task<IResult> CreateBook(IBookRepository bookRepository,
            IMapper _mapper, BookCreateDTO book_C_DTO)
        {
            ResponseModel response = new() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };


            if (bookRepository.GetByBookName(book_C_DTO.Title).GetAwaiter().GetResult() != null)
            {
                response.ErrorMessages.Add("This Book is already in your collection");
                return Results.BadRequest(response);
            }
            Book book = _mapper.Map<Book>(book_C_DTO);
            await bookRepository.CreateAsync(book);
            await bookRepository.SaveAsync();
            BookDTO bookDTO = _mapper.Map<BookDTO>(book);

            response.Result = bookDTO;
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.Created;

            return Results.Ok(response);
        }


        private async static Task<IResult> GetBook(IBookRepository bookRepository, int id)
        {
            ResponseModel response = new ResponseModel();

            response.Result = await bookRepository.GetByBookId(id);
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;

            return Results.Ok(response);
        }

        private async static Task<IResult> UpdateBook(
           IBookRepository bookRepository,
           IMapper _mapper,
           BookUpdateDTO book_U_DTO)
        {
            ResponseModel response = new ResponseModel() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };
            var existingBook = await bookRepository.GetByBookId(book_U_DTO.BookId);
            if (existingBook == null)
            {
                response.ErrorMessages.Add("Book not found");
                return Results.NotFound(response);
            }
            _mapper.Map(book_U_DTO, existingBook);

            await bookRepository.UpdateAsync(existingBook);
            await bookRepository.SaveAsync();

            response.Result = _mapper.Map<BookUpdateDTO>(await bookRepository.GetByBookId(book_U_DTO.BookId));
            response.IsSuccess = true;
            response.StatusCode = System.Net.HttpStatusCode.OK;
            return Results.Ok(response);

        }

        private async static Task<IResult> DeleteBook(IBookRepository bookRepository, int id)
        {
            ResponseModel response = new ResponseModel() { IsSuccess = false, StatusCode = System.Net.HttpStatusCode.BadRequest };

            Book bookFromDb = await bookRepository.GetByBookId(id);

            if (bookFromDb != null)
            {
                await bookRepository.DeleteAsync(bookFromDb);
                await bookRepository.SaveAsync();

                response.IsSuccess = true;
                response.StatusCode = System.Net.HttpStatusCode.NoContent;
                return Results.Ok(response);
            }
            else
            {
                response.ErrorMessages.Add("Invalid ID");
                return Results.BadRequest(response);
            }
        }
    }    
}
