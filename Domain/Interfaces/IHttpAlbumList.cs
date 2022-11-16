   using OpenDataApi.Domain.Models;

    namespace OpenDataApi.Domain.Interfaces
    {
        public interface IHttpAlbumList
        {
            Task<IEnumerable<Album>> ListAsync();
           
              
        }
    }