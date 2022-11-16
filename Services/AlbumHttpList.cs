using OpenDataApi.Domain.Models;
using OpenDataApi.Domain.Interfaces;
using System.Text.Json;

namespace OpenDataApi.Services
{

    public class AlbumHttpList : IHttpAlbumList
    {
        private readonly HttpClient _client;
        public const string BasePath = "http://jsonplaceholder.typicode.com/albums";
        public AlbumHttpList(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            
       
        }
         
        public async Task<IEnumerable<Album>> ListAsync()
        {
            //get photos from api
            var response = await _client.GetAsync(BasePath);

            // deserialize 
            if (response.IsSuccessStatusCode == false)
                throw new ApplicationException($"Something went wrong calling the API: {response.ReasonPhrase}");
            
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            
            var result =  JsonSerializer.Deserialize<List<Album>>(
                dataAsString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            if (result == null)
                throw new ArgumentNullException($"Something went wrong calling the API: No albums found.");
                
            return  result;
            
        }
    }
}