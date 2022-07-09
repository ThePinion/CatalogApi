namespace CatalogApiProject.Models
{
    public class PartialTrack
    {
        public string? Title { get; set; }

        public TimeSpan? Duration { get; set; }

        public List<ArtistRole> Artists { get; set; } = new();

        public Track ToTrack(Record record)
        {
            Console.WriteLine(Title);
            return new Track()
            {
                Title = Title,
                Duration = Duration,
                Artists = Artists,
            };
        }
    }
    public class PartialRecord
    {
        public long? Id { get; set; }
        public string? Title { get; set; }
        public int? PublishedYear { get; set; }
        public string? Location { get; set; }
        public List<ArtistRole> Artists { get; set; } = new();
        public List<PartialTrack> PartialTracks { get; set; } = new();
        public string? Additional { get; set; }

        public void ToRecord(Record record)
        {
            record.Title = Title;
            record.PublishedYear = PublishedYear;
            record.Location = Location;
            record.Artists = Artists;
            record.Additional = Additional;
            //record.Tracks.AddRange(PartialTracks.Select(x => x.ToTrack(record)));
        }
    }
}
