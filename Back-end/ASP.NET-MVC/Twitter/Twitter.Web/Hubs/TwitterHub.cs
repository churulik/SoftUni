using System.Web.Mvc;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Twitter.Web.Models;
using Twitter.Web.Models.ViewModel;

namespace Twitter.Web.Hubs
{
    [HubName("twitter")]
    public class TwitterHub : Hub
    {
    }
}