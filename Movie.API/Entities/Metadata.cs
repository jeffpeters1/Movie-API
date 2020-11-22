using System.ComponentModel.DataAnnotations;

namespace Movie.API.Entities
{
    public class Metadata
    {
        [Key]
        public int Id { get; set; }

        public int MovieId { get; set; }

        public string Title { get; set; }

        public string Language { get; set; }

        public string Duration { get; set; }

        public string ReleaseYear { get; set; }
    }
}
