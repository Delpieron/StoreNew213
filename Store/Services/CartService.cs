using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Data;
using Store.Helpers;
using Store.Models;

namespace Store.Services
{
    public class CartService : ICartService
    {
        private readonly DataContext dbContext;
        private readonly IUser user;

        public CartService(DataContext dbContext, IUser user)
        {
            this.dbContext = dbContext;
            this.user = user;
        }
        public async Task<Cart> GetAsync(Cart cart)
        {
            return await dbContext.Cart.Include(x => x.Product).SingleOrDefaultAsync(x=>x.Id == cart.Id);
        }
        public async Task<ICollection<Cart>> GetAllAsync()
        {

            return await dbContext.Cart.Include(x => x.Product).ToListAsync(); 

        }


        public async Task<Cart> addCartAsync(Cart cart)
        {

            cart.OwnerUserId = user.Id;
            var exist = dbContext.Cart.FirstOrDefaultAsync(x => x.OwnerUserId == user.Id);
            if (exist!=null)
            {
                dbContext.Cart.Update(cart);
                
            }
            else
            {
                await dbContext.Cart.AddAsync(cart);
            }

            await dbContext.SaveChangesAsync();
            var itemToReturn = await GetAsync(cart);
            return itemToReturn;
        }


    }
}
