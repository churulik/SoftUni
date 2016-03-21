using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BookShop.Models.UserAuthentication
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync
            (UserManager<ApplicationUser> manager, string authenticationType)
        {

            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            
            return userIdentity;
        }

        private ICollection<Purchase> _purchases;

        public ApplicationUser()
        {
            this._purchases = new HashSet<Purchase>();
        }

        public virtual ICollection<Purchase> Purchases
        {
            get { return _purchases; }
            set { this._purchases = value; }
        }
    }
}
