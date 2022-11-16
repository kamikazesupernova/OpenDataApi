   using OpenDataApi.Domain.Models;

    namespace OpenDataApi.Domain.Interfaces
    {
        public interface IHttpPhotoList
        {
            Task<IEnumerable<Photo>> ListAsync();
           
              
        }
    }