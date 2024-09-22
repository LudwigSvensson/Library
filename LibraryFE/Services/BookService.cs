using Library.Models.DTO_s;

namespace LibraryFE.Services
{
    public class BookService : BaseService, IBookService
    {
        public BookService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<T> CreateBookAsync<T>(BookDTO bookDto)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                Type = StaticDetails.ApiType.POST,
                Data = bookDto,
                Url = StaticDetails.BookApiBase + "/api/book",
                AccessToken = ""
            });
        }

        public async Task<T> DeleteBookAsync<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                Type = StaticDetails.ApiType.DELETE,
                Url = StaticDetails.BookApiBase + "/api/book/" + id, 
                AccessToken = ""
            });
        }

        public Task<T> GetAllBooks<T>()
        {
            return this.SendAsync<T>(new Models.ApiRequest()
            {
                Type = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/books",
                AccessToken = ""
            });
        }

        public async Task<T> GetBookById<T>(int id)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                Type = StaticDetails.ApiType.GET,
                Url = StaticDetails.BookApiBase + "/api/book/" + id,
                AccessToken = ""
            });
        }

        public async Task<T> UpdateBookAsync<T>(BookDTO bookDto)
        {
            return await this.SendAsync<T>(new Models.ApiRequest
            {
                Type = StaticDetails.ApiType.PUT,
                Data = bookDto,
                Url = StaticDetails.BookApiBase + "/api/book",
                AccessToken = ""
            });
        }
    }
}
