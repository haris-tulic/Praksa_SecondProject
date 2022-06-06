namespace Praksa_SecondProject.Helpers
{
    public class PageList<T>:List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotatCount { get; set; }
        public bool HasPrevious => (CurrentPage>1); 
        public bool HasNext => (CurrentPage<TotalPages);
        public PageList(List<T> items,int currentPage, int pageSize, int totatCount)
        {
            CurrentPage = currentPage;
            TotalPages = (int) Math.Ceiling(totatCount/(double) pageSize);
            PageSize = pageSize;
            TotatCount = totatCount;
            AddRange(items);
        }
        public static PageList<T> Create(IQueryable<T> source,int pageNumber,int pageSize)
        {
            var count = source.Count();
            var items=source.Skip((pageNumber-1)*pageSize).Take(pageSize).ToList();
            return new PageList<T>(items,pageNumber,pageSize,count);
        }
    }
}
