    namespace OpenDataApi.Domain.Models
    {
        public class Photo
        {
            public int AlbumId { get; set; }
            public int id { get; set; }
            public string? title { get; set; }
            public string? url { get; set; }
            public string? thumbnailUrl { get; set; }
        }
    }