using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Web;

namespace ArtikutClient.Models
{
    public class PaginatedList<T>
    {
        public IEnumerable<T> Models { get; }
        public int NumberOfPages { get; }

        public IList<Page> Pages { get; } = new List<Page>();

        public PaginatedList(IEnumerable<T> models, int numberOfPages, int currentPageIndex)
        {
            Models = models;
            NumberOfPages = numberOfPages;

            for (int i = 1; i <= NumberOfPages; i++)
            {
                Pages.Add(new Page(i, i == currentPageIndex));
            }
        }
    }

    public struct Page
    {
        public int Index { get; }
        public bool IsActive { get; }

        public Page(int index, bool isActive)
        {
            Index = index;
            IsActive = isActive;
        }
    }


}