namespace IfrsDocs.Domain.Entities.Pagination
{
    public class PageParams
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        public int pageSize = 10;
        private int PageSize 
        {
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; } 
        }
        public string Name { get; set; } = string.Empty;


    }
}
