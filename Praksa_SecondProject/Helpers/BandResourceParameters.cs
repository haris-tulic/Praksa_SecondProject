namespace Praksa_SecondProject.Helpers
{
    public class BandResourceParameters
    {
        public string Genre { get; set; }
        public string SearchQuery { get; set; }
        const int maxSize = 3;
        public int PageNumber { get; set; } = 1;
        private int _pageSize=2;

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = (value>maxSize)?maxSize:value; }
        }

    }
}
