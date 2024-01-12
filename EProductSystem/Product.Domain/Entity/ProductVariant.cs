using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Product.Domain.Entity
{
    /// <summary>
    /// 商品种类
    /// </summary>
    public class ProductVariant : IAggregateRoot
    {
        public Guid Id { get; init; }
        [JsonIgnore]
        public Product? Product { get; private set; }

        public Guid ProductId { get; private set; }
        public ProductType? ProductType { get; private set; }
        public Guid ProductTypeId { get; private set; }
        public decimal Price { get; private set; }
        public decimal OriginalPrice { get; private set; }
        public bool Visible { get; private set; }
        public bool Deleted { get; private set; }

        public ProductVariant()
        {

        }

        public ProductVariant(Guid productId, Guid typeId, decimal originalPrice, decimal price, bool visible = true, bool deleted = false)
        {
            Id = Guid.NewGuid();
            ProductId = productId;
            ProductTypeId = typeId;
            OriginalPrice = originalPrice;
            Price = price;
            Visible = visible;
            Deleted = deleted;
        }


        public void UpdateType(ProductType type)
        {
            if (type.Name == ProductType.Name)
            {
                Console.WriteLine("已经存在套餐");
                return;
            }
            ProductType = type;
        }

        public void VariantVisible()
        {
            if (Visible)
            {
                Console.WriteLine("该变体已经是可见状态");
                return;
            }
            this.Visible = true;
        }

        public void VariantInVisible()
        {
            if (!Visible)
            {
                Console.WriteLine("该变体已经是不可见状态");
                return;
            }
            this.Visible = false;
        }

        public void ProductDelete()
        {
            if (Deleted)
            {
                Console.WriteLine("该套餐已删除");
                return;
            }
            this.Visible = false;
            this.Deleted = true;
        }

    }
}
