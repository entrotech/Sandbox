using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sandbox.Web.Models.Responses
{
    public class PagedItemsResponse<T> : ItemsResponse<T>
    {
        public PagedItemsResponse(int pageNumber, int itemsPerPage, int totalItems, List<T> items) 
        {
            PageNumber = pageNumber;
            ItemsPerPage = itemsPerPage;
            TotalItems = totalItems;
            Items = items;
        }

        public int TotalItems { get; private set; }
        public int PageNumber { get; private set; }
        public int ItemsPerPage { get; private set; }

        public int TotalPages { get
            {
                return (int)Math.Ceiling((double)TotalItems / ItemsPerPage);
            }
        }

        public bool HasPreviousPage
        {
            get { return PageNumber > 0;  }
        }

        public bool HasNextPage
        {
            get { return PageNumber < TotalPages; }
        }
    }
}