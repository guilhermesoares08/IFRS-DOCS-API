using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace IfrsDocs.Domain.Entities.Pagination
{

    public class PageList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PageList() { }

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PageList<T> Create(
            IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count =  source.Count();
            var items =  source.Skip((pageNumber - 1) * pageSize)
                                    .Take(pageSize)
                                    .ToList();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
