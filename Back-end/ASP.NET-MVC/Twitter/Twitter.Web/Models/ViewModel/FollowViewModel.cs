using System.Collections.Generic;
using PagedList;

namespace Twitter.Web.Models.ViewModel
{
    public class FollowViewModel : IPagedList
    {
        public IEnumerable<TweetViewModel> Tweets { get; set; }
        public int PageCount { get; }
        public int TotalItemCount { get; }
        public int PageNumber { get; }
        public int PageSize { get; }
        public bool HasPreviousPage { get; }
        public bool HasNextPage { get; }
        public bool IsFirstPage { get; }
        public bool IsLastPage { get; }
        public int FirstItemOnPage { get; }
        public int LastItemOnPage { get; }
    }
}