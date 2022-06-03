namespace Praksa_SecondProject.Database
{
    public class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Founded { get; set; }
        public string MainGenre { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
