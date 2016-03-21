using System;
using BookShop.Models.UserAuthentication;

namespace BookShop.Models
{
    public class Purchase
    {
        public int Id { get; set; }

        //[Required]
        //public string Username { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public bool IsRecalled { get; set; }

        public virtual Book Book { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}