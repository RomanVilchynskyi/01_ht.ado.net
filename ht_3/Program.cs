using ht_3.Entities;
using ht_3;

internal class Program
{
    private static void Main(string[] args)
    {
        var db = new MusicContext();

        db.Artists.Add(new Artist { FirstName = "John", LastName = "Doe", Country = "USA" });
        db.Artists.Add(new Artist { FirstName = "Emma", LastName = "Stone", Country = "UK" });
        db.Artists.Add(new Artist { FirstName = "Carlos", LastName = "Santana", Country = "Mexico" });
        db.SaveChanges();

        db.Albums.Add(new Album { Name = "Greatest Hits", Year = 2020, Genre = "Pop", ArtistId = db.Artists.FirstOrDefault(a => a.FirstName == "John").Id });
        db.Albums.Add(new Album { Name = "Rock Anthems", Year = 2018, Genre = "Rock", ArtistId = db.Artists.FirstOrDefault(a => a.FirstName == "Carlos").Id });
        db.SaveChanges();

        db.Tracks.Add(new Track { Name = "Song 1", AlbumId = db.Albums.FirstOrDefault(a => a.Name == "Greatest Hits").Id, Duration = 180 });
        db.Tracks.Add(new Track { Name = "Song 2", AlbumId = db.Albums.FirstOrDefault(a => a.Name == "Greatest Hits").Id, Duration = 240 });
        db.Tracks.Add(new Track { Name = "Rock Track", AlbumId = db.Albums.FirstOrDefault(a => a.Name == "Rock Anthems").Id, Duration = 210 });
        db.SaveChanges();

        db.Playlists.Add(new Playlist { Name = "My Playlist", Category = "Favorites", Tracks = new List<Track> { db.Tracks.FirstOrDefault(t => t.Name == "Song 1"), db.Tracks.FirstOrDefault(t => t.Name == "Rock Track") } });
        db.SaveChanges();
       
    }
}

    
