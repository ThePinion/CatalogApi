using DiscogsClient.Internal;
using DiscogsClient;
using DiscogsClient.Data.Query;
using CatalogApiProject.Models;

namespace CatalogApiProject.Controllers
{
    public class Discogs
    {
        private static readonly string token = "WxcRiFfHqbMmuSBnxnikvmVHrCvYRzznuyiBjUdi";
        private static readonly TokenAuthenticationInformation tokenInformation = new TokenAuthenticationInformation(token);
        private static readonly DiscogsClient.DiscogsClient discogsClient = new DiscogsClient.DiscogsClient(tokenInformation);


        public static async Task<IList<DiscogsClient.Data.Result.DiscogsSearchResult>> SearchQueryAsync(string query)
        {
            var discogsSearch = new DiscogsSearch()
            {
                query = query
            };

            var search = await discogsClient.SearchAsync(discogsSearch);
            var results = search.GetResults();
            return results;
        }

        public static async Task<Record> ResultQueryAsync(int resultId)
        {
            var release = await discogsClient.GetReleaseAsync(resultId);
            return new Record
            {
                Title = release.title,
                PublishedYear = release.year,
                Tracks = release.tracklist.Select(t => new Track() { 
                    Title = t.title, 
                    Duration = t.duration, 
                    Subtracks = t.sub_tracks?.Select(s => new Track() { 
                        Title = s.title, 
                        Duration = s.duration 
                    }).ToList()
                }).ToList()
            };
        }
    }
}
