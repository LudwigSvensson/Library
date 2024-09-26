using static Library.Models.Book;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace Library.Models.DTO_s
{
    public class BookDTO
    {
        [DisplayName("ID")]
        public int BookId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        [DisplayName("Genre")]
        [Required]
        public Book.Genre BookGenre { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy}")]
        [DisplayName("Release Year")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime RealeseYear { get; set; }
    }
}
