using ht_3.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ht_3
{
    public class MusicContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source= DESKTOP-F5EBSVM\SQLEXPRESS;
                                Initial Catalog = MusicApp;
                                Integrated Security=True;
                                Connect Timeout=2;
                                Encrypt=False;
                                Trust Server Certificate=False;
                                Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Playlist> Playlists { get; set; }

    }
}
