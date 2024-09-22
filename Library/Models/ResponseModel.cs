using System.Net;

namespace Library.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {
            ErrorMessages = new List<string>();
        }

        public bool IsSuccess { get; set; }
        public Object Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
