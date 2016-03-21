using System.Collections.Generic;
using PagedList;
using Twitter.Web.Models.BindingModel;
using Twitter.Web.Models.ViewModel;

namespace Twitter.Web.Models
{
    public class HomeModel 
    {

        public FavoriteBindingModel FavoriteBindingModel { get; set; }
        public TweetBindingModel TweetBindingModel { get; set; }
        public TweetViewModel TweetViewModel { get; set; }
        public RetweetBindigModel RetweetBindigModel { get; set; }
        public ReportBindingModel ReportBindingModel { get; set; }
        public ReplayBindingModel ReplayBindingModel { get; set; }
        public ChannelBindingModel ChannelBindingModel { get; set; }
        public ChannelViewModel ChannelViewModel { get; set; }
        public IndexViewModel IndexViewModel { get; set; }
        public NotificationsBindingModel NotificationsBindingModel { get; set; }
        public NotificationsViewModel NotificationsViewModel { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }

        public PagedList<TweetViewModel> PageListTweetViewModel { get; set; }
        public PagedList<FollowViewModel> FollowViewModel { get; set; }

        public IEnumerable<ChannelViewModel> EnumChannelViewModel { get; set; }
        public IEnumerable<ReplayViewModel> EnumReplayViewModel { get; set; }
        public IEnumerable<TweetViewModel> EnumTweetViewModel { get; set; }
        public IEnumerable<FollowersViewModel> EnumFollowersViewModel { get; set; }
        public IEnumerable<FavoriteViewModel> EnumFavoriteViewModel { get; set; }
        public IEnumerable<NotificationsViewModel> EnumNotificationsViewModel { get; set; }

    }
}