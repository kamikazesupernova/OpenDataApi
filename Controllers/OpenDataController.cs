using Microsoft.AspNetCore.Mvc;
using OpenDataApi.Domain.Interfaces;
using OpenDataApi.Domain.Models;

namespace OpenDataApi.Controllers
{
    [Route("/api/[controller]")]
    public class AlbumPhotosController : Controller
    {
        private readonly IHttpPhotoList _photoHttpList;
        private readonly IHttpAlbumList _albumHttpList;
        private readonly IPhotoAlbumList _photoAlbumList;
        public AlbumPhotosController(IHttpPhotoList photoHttpList, IHttpAlbumList albumHttpList, IPhotoAlbumList photoAlbumList )
        {
            _photoHttpList = photoHttpList; 
            _albumHttpList = albumHttpList;
            _photoAlbumList = photoAlbumList; 
        }
        [HttpGet]
        public async Task<IEnumerable<PhotoAlbum>> GetAllAsync()
        {
            //Query endpoints
            var photos = await _photoHttpList.ListAsync();
            var albums = await _albumHttpList.ListAsync(); 
            //Merge logic       
            var photoalbum = _photoAlbumList.LinqList(albums, photos);

            return photoalbum;
        }
        [HttpGet("{id}")]
        public async Task<IEnumerable<PhotoAlbum>> GetAllById(int id)
        {
            System.Diagnostics.Debug.WriteLine("This is a log: " + id.ToString());

            var photos = await _photoHttpList.ListAsync();
            var albums = await _albumHttpList.ListAsync();

            var photoalbum = _photoAlbumList.ListById(albums, photos, id);

            return photoalbum;
        }
    }
}