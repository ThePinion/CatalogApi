namespace CatalogApiProject.Models
{
    public class Record
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public int? PublishedYear { get; set; }

        public string? Location { get; set; }

        public List<ArtistRole> Artists { get; set; } = new();
        public List<Track> Tracks { get; set; } = new();
        public string? Additional { get; set; }
    }
}
