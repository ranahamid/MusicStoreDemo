using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Album
    {
        public virtual int AlbumId { get; set; }
        public virtual int GenreID { get; set; }
        public virtual int ArtistId { get; set; }
        public virtual string Title { get; set; }
        public virtual decimal Price { get; set; }
        public virtual string AlbumArtUrl { get; set; }

        public virtual Artist artist { get; set; }
        public virtual Genre  genre { get; set; }


    }

    public class Artist
    {
        public virtual int ID { get; set; }
        public virtual string Name { get; set; }
    }


    public class Genre
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual List<Album> albums { get; set; }
    }

}