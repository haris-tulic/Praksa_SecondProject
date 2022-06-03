using Microsoft.EntityFrameworkCore;

namespace Praksa_SecondProject.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Band> Bands { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            model.Entity<Band>().HasData(new Band()
            {
                Id = 1,
                Name = "Metalica",
                Founded = new DateTime(1980, 1, 1),
                MainGenre = "Heavy Metal"
            },
            new Band() { Id = 2, Name ="Guns N Roses", Founded=new DateTime(1985,3,1),MainGenre="Rock" },
            new Band() { Id = 3, Name ="ABBA", Founded=new DateTime(1965,7,1),MainGenre="Disco" },
            new Band() { Id = 4, Name = "Guns N Roses", Founded = new DateTime(1985, 2, 1), MainGenre = "Rock" },
            new Band() { Id = 5, Name = "A-ha", Founded = new DateTime(1986, 6, 1), MainGenre = "Pop" }

            );
            model.Entity<Album>().HasData(
                new Album
                {
                    Id = 1,
                    Title = "Master Of Puppets",
                    Description = "One of the best heavy metal albums ever",
                    BandId = 1
                },
                new Album
                {
                    Id = 2,
                    Title = "Appetite for Destruction",
                    Description = "Amazing Rock album with raw sound",
                    BandId = 2
                },
                new Album
                {
                    Id = 3,
                    Title = "Waterloo",
                    Description = "Very groovy album",
                    BandId = 3
                },
                new Album
                {
                    Id = 4,
                    Title = "Be Here Now",
                    Description = "Arguably one of the best albums by Oasis",
                    BandId = 4
                },
                new Album
                {
                    Id = 5,
                    Title = "Hunting Hight and Low",
                    Description = "Awesome Debut album by A-Ha",
                    BandId = 5
                });
            base.OnModelCreating(model);
        } 
    }
}
