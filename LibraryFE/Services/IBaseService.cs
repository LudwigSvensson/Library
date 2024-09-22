using LibraryFE.Models;

namespace LibraryFE.Services
{
    public interface IBaseService
    {
        ResponseDTO responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
