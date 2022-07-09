namespace CatalogApiProject.Models
{
    public class Track
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public TimeSpan? Duration { get; set; }
        public List<ArtistRole> Artists { get; set; } = new();

        public List<Track>? Subtracks { get; set; }
    }
}
