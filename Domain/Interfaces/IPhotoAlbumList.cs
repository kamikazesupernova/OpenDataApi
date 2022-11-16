   using OpenDataApi.Domain.Models;

    namespace OpenDataApi.Domain.Interfaces
    {
        public interface IPhotoAlbumList
        {
            IEnumerable<PhotoAlbum> List(List<Album> albums, List<Photo> photos);
            IEnumerable<PhotoAlbum> LinqList(IEnumerable<Album> albums, IEnumerable<Photo> photos);
            IEnumerable<PhotoAlbum> ListById(IEnumerable<Album> albums, IEnumerable<Photo> photos, int id);            
              
        }
    }