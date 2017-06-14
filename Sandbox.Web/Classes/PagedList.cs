using System;
using System.Collections.Generic;
using System.Linq;

namespace Sandbox.Web
{
    public class PagedList<T>
    {
       

        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public int TotalCount { get; private set; }

        public int TotalPages { get; private set; }

        public List<T> PagedItems { get; private set; }

        /// <summary>
        /// This constructor to be used when we are doing paging in .Net
        /// </summary>
        /// <param name="data"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        public PagedList(List<T> data, int page, int pagesize)
        {
            PageIndex = page;
            PageSize = pagesize;
            if (data != null)
            {
                TotalCount = data.Count;
                TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
            }

            if (data != null)
            {
                this.PagedItems = data.Skip(PageIndex * PageSize).Take(PageSize).ToList();
            }
        }

        /// <summary>
        /// This constructor to be used when using database paging
        /// </summary>
        /// <param name="data"></param>
        /// <param name="page"></param>
        /// <param name="pagesize"></param>
        /// <param name="totalCount"></param>
        public PagedList(List<T> data, int page, int pagesize, int totalCount)
        {
            PageIndex = page;
            PageSize = pagesize;
            PagedItems = data;

            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
        }

        public PagedList(List<T> data, int pageCount)
        {
            PagedItems = data;
            TotalPages = pageCount;
        }

        public bool HasPreviousPage
        {
            get { return (PageIndex > 0); }
        }


        public bool HasNextPage
        {
            get { return (PageIndex + 1 < TotalPages); }
        }

    }

}