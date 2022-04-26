using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class MusicStoreDbInitializer: DropCreateDatabaseAlways<MusicStoreDB>

    {
        protected override void Seed(MusicStoreDB context)
        {
            context.artists.Add(new Artist
            {
                Name = "Atif Aslam"
            });

            context.genres.Add(new Genre
            {
                Name="Jazz",
                Description="Jazz description"
            });

            context.albums.Add(new Album
            {
                artist=new Artist { Name="Atif Aslam"},
                genre=new Genre { Name= "Jazz" },
                Price=9.99m,
                Title="Coravan",
                AlbumArtUrl="google.com/pop/coravan",
              
            });

            context.albums.Add(new Album
            {
                artist = new Artist { Name = "Atif Aslam" },
                genre = new Genre { Name = "Jazz" },
                Price = 11.00m,
                Title = "Jingel",
                AlbumArtUrl = "google.com/pop/Jingel",

            });

            context.albums.Add(new Album
            {
                artist = new Artist { Name = "Atif Aslam" },
                genre = new Genre { Name = "Jazz" },
                Price = 4.5m,
                Title = "Resmia",
                AlbumArtUrl = "google.com/Nose/HimesNose",

            });


            base.Seed(context);
        }
    }
}