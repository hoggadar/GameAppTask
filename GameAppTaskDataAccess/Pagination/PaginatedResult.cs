namespace GameAppTaskDataAccess.Pagination
{
    public class PaginatedResult<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);

        public PaginatedResult(IEnumerable<T> items, int pageSize, int currentPage, int totalCount)
        {
            Items = items;
            PageSize = pageSize;
            CurrentPage = currentPage;
            TotalCount = totalCount;
        }
    }
}
