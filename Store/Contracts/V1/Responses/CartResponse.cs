using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Contracts.V1.Responses
{
    public class CartResponse
    {
        public int Id { get; set; }
        public string OwnerUserId { get; set; }
        public int ProductId { get; set; }
        public int Count { get; set; }
        public ProductResponse Price { get; set; }

    }
}
