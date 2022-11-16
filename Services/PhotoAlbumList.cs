using OpenDataApi.Domain.Models;
using OpenDataApi.Domain.Interfaces;

namespace OpenDataApi.Services{

    public class PhotoAlbumList : IPhotoAlbumList
    {
        public PhotoAlbumList()
        {          
                   
        }
        public IEnumerable<PhotoAlbum> List(List<Album> albums, List<Photo> photos)
        {
            //TODO It would be better to add a custom equality comparer to match on a partial key   
            var albumsList = new Dictionary<int, List<Photo>>();
            var photoalbums = new List<PhotoAlbum>();
            //populate albums
            foreach (Album a in albums)
            {
                albumsList.Add(a.id, new List<Photo>());

            }
            //populate photos
            foreach (Photo p in photos)
            {
                if (albumsList.ContainsKey(p.AlbumId))
                {
                    albumsList[p.AlbumId].Add(p);
                }
            }

            foreach (KeyValuePair<int, List<Photo>> entry in albumsList)
            {
                // throw ex if not found
                var item = albums.Single(x => x.id == entry.Key);
                photoalbums.Add(new PhotoAlbum
                {
                    album = item
                    ,
                    photos = entry.Value
                });
            }

            return photoalbums;
        }
        public IEnumerable<PhotoAlbum> LinqList(IEnumerable<Album> albums, IEnumerable<Photo> photos)
        {             

      
                      var result = (from a in albums
                          join p in photos on a.id equals p.AlbumId into pa
                          select new PhotoAlbum
                          {
                              album = a
                              ,photos = (from p in pa                                         
                                         select new Photo {
                                            AlbumId = p.AlbumId 
                                            ,id = p.id
                                            ,title = p.title 
                                            ,url = p.url
                                            ,thumbnailUrl = p.thumbnailUrl}).ToList()
                           })
                .ToList();


                return result;
        
 
        }
        public IEnumerable<PhotoAlbum> ListById(IEnumerable<Album> albums, IEnumerable<Photo> photos, int id)
        {
                          var result = (from a in albums
                          join p in photos on a.id equals p.AlbumId into pa
                          where a.UserId == id
                          select new PhotoAlbum
                          {
                              album = a
                              ,photos = (from p in pa                                         
                                         select new Photo {
                                            AlbumId = p.AlbumId 
                                            ,id = p.id
                                            ,title = p.title 
                                            ,url = p.url
                                            ,thumbnailUrl = p.thumbnailUrl}).ToList()
                           })
                .ToList();
                 //TODO If none found return user friendly result

                return result;

        }
        
    }

}
