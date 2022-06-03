namespace Praksa_SecondProject.Database
{
    public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BandId { get; set; }
        public Band Band { get; set; }
    }
}