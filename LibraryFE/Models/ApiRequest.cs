using static LibraryFE.StaticDetails;

namespace LibraryFE.Models
{
    public class ApiRequest
    {
        public ApiType Type { get; set; }

        public string Url { get; set; }

        public object Data { get; set; }
        public string AccessToken { get; set; }

    }
}
