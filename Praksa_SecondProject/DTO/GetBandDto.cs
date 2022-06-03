namespace Praksa_SecondProject.DTO
{
    public class GetBandDto
    {
        public string Name { get; set; }
        public DateTime Founded { get; set; }
        public string MainGenre { get; set; }
        public List<GetAlbumDto> Albums { get; set; }
    }
}
