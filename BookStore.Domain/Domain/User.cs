using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domain.Domain
{
    public class User : IdentityUser
    {
        
        public ShoppingCart? UserCart { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }
    }
}
