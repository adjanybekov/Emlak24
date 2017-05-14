using System;
using System.Collections.Generic;
using Wohnungstausch24.Core;

namespace Wohnungstausch24.Models.ViewModels.Common
{
    public class PagedListViewModel<T> where T : class
    {
        public List<T> Items { get; set; }
        public Pager Pager { get; set; }
    }
    public class Pager
    {
        public Pager(int totalItems, int? page, int? itemsPerPage)
        {
            if (itemsPerPage ==null || itemsPerPage > 50 || itemsPerPage < 0)
            {
                itemsPerPage = Constants.ItemsPerPage;
            }

            var totalPages = (int)Math.Ceiling(totalItems / (decimal)itemsPerPage);
            var currentPage = (page < 0 || page==null)? 1:page.Value;
            var startPage = currentPage - 5;
            var endPage = currentPage + 5;

            if (startPage <= 0)
            {
                endPage = endPage - (startPage - 1);
                startPage = 1;
            }
            if (endPage > totalPages)
            {
                endPage = totalPages;
                if (endPage > 10)
                {
                    startPage = endPage - 9;
                }
            }

            TotalItems = totalItems;
            CurrentPage = currentPage;
            ItemsPerPage = itemsPerPage.Value;
            TotalPages = totalPages;
            StartPage = startPage;
            EndPage = endPage;
        }

        public int TotalItems { get; private set; }
        public int CurrentPage { get; private set; }
        public int ItemsPerPage { get; private set; }
        public int TotalPages { get; private set; }
        public int StartPage { get; private set; }
        public int EndPage { get; private set; }
    }
}
