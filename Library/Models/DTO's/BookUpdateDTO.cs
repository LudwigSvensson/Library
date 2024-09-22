using static Library.Models.Book;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library.Models.DTO_s
{
    public class BookUpdateDTO
    {
        public int BookId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public string Author { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Genre BookGenre { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        public DateTime RealeseYear { get; set; }
        public BookUpdateDTO()
        {
            
        }
    }
}
