using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class MusicStoreDB:DbContext
    {
        public MusicStoreDB(): base("name=someOtherDBName")
        {

        }
        public DbSet<Album> albums { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Artist> artists { get; set; }

        public System.Data.Entity.DbSet<MusicStore.Models.Order> Orders { get; set; }
    }
}