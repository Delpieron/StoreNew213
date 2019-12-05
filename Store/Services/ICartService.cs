using Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Services
{
    public interface ICartService
    {
        Task<Cart> GetAsync(Cart id);
        Task<ICollection<Cart>> GetAllAsync();
        Task<Cart> addCartAsync(Cart cart);
    }
}
