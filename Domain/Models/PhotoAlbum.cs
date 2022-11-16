    namespace OpenDataApi.Domain.Models
    {
        public class PhotoAlbum
        {
            public Album album { get; set; } = new Album();
            public IList<Photo> photos { get; set; } = new List<Photo>();
        }
    }