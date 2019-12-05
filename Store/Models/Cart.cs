using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public IdentityUser OwnerUser { get; set; }
        public  string OwnerUserId { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
