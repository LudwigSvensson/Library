using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }

        [MaxLength(50)]
        public string Title { get; set; }

        public string  Author { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Genre BookGenre { get; set; }

        [DisplayFormat(DataFormatString ="{0:yyyy}")]
        public DateTime RealeseYear { get; set; }

        public enum Genre
        {
            Deckare,
            Biografi,
            Romantik,
            Fantasy,
            Scifi,
            Självbiografi
        }
    }
}
