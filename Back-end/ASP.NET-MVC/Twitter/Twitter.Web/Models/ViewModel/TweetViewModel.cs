using System;
using System.Collections.Generic;
using PagedList;
using Twitter.Models;

namespace Twitter.Web.Models.ViewModel
{
    public class TweetViewModel : IPagedList
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Username { get; set; }
        public string Content { get; set; }
        public string CreatedOn { get; set; }
        public int ChannelId { get; set; }
        public int FavoritesCount { get; set; }
        public int ReplaysCount { get; set; }
        public string MyUsername { get; set; }
        public string ImageUrl { get; set; }

        public int PageCount { get; }
        public int TotalItemCount { get; }
        public int PageNumber { get; }
        public int PageSize { get; set; }
        public bool HasPreviousPage { get; }
        public bool HasNextPage { get; }
        public bool IsFirstPage { get; }
        public bool IsLastPage { get; }
        public int FirstItemOnPage { get; }
        public int LastItemOnPage { get; }
    }
}