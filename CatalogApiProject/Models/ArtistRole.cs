namespace CatalogApiProject.Models
{
    public class ArtistRole
    {
        public long Id { get; set; }

        public long ArtistId { get; set; }
        public Artist? Artist { get; set; }
        public long RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
