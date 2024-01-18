using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Domain.Entity
{
    public class CartItem
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }    

        public Guid ProductId { get;set; }

        public Guid ProductTypeId { get; set; }

        public int Quantity { get; private  set; }

        public CartItem()
        {
                
        }

        public CartItem(Guid productId, Guid productTypeId, int quantity = 1)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            ProductTypeId = productTypeId;
            Quantity = quantity;
        }

        public void UpdateQuantity(int quantity)
        {
            if (Quantity == quantity) return;

            Quantity = quantity;
        }

        public void SetUserId(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
