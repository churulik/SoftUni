namespace Twitter.Web.Models.ViewModel
{
    public class NotificationsViewModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public string Date { get; set; }

        public string Username { get; set; }

        public string User { get; set; }

        public bool Read { get; set; }

        public int ReadCount { get; set; }
    }
}