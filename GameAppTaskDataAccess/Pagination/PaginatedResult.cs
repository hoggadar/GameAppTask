using Microsoft.EntityFrameworkCore;

namespace GameAppTaskDataAccess.Pagination
{
    public class PaginatedResult<T> where T : class
    {
        public IEnumerable<T> Items { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;


        public PaginatedResult(IEnumerable<T> items, int pageSize, int currentPage, int count, int totalCount)
        {
            Items = items;
            PageSize = pageSize;
            CurrentPage = currentPage;
            Count = count;
            TotalCount = totalCount;
        }

        public static async Task<PaginatedResult<T>> CreateAsync(IQueryable<T> source, int pageSize, int currentPage)
        {
            var totalCount = await source.CountAsync();
            var count = (int)Math.Ceiling((double)totalCount / pageSize);
            var items = await source.Skip((currentPage - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PaginatedResult<T>(items, pageSize, currentPage, count, totalCount);
        }
    }
}
