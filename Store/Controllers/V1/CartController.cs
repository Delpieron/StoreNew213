using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store.Contracts.V1;
using Store.Contracts.V1.Requests;
using Store.Contracts.V1.Responses;
using Store.Helpers;
using Store.Models;
using Store.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Controllers.V1
{
    [Authorize]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        public CartController(ICartService cartService, IMapper mapper)
        {
            this.cartService = cartService;
            this.mapper = mapper;
        }
        [HttpPost(ApiRoutes.Cart.Add)]
        public async Task<IActionResult> AddAsync([FromBody]CartRequest cartRequest)
        {
            var newCart = mapper.Map<Cart>(cartRequest);
            var cart = await cartService.addCartAsync(newCart);
            return Ok(cart);            
            
        }
        [AllowAnonymous]
        [HttpGet(ApiRoutes.Cart.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            var carts = await cartService.GetAllAsync();            
            var response = mapper.Map<ICollection<CartResponse>>(carts);
            return Ok(response);
        }
    }
}
