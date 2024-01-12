using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entity
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Product: IAggregateRoot
    {
        public Guid Id { get; init; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public string ImageUrl { get; private set; }

        public Category? Category { get; private set; }

        public Guid CategoryId { get; private set; }

        public List<ProductVariant> Variants { get; private set; }

        public bool Featured { get; private set; }

        public bool Visible { get; private set; }

        public bool Deleted { get; private set; }

        public Product()
        {

        }

        public Product(string title, string description, string imageurl, Guid categoryId, List<ProductVariant> variants, bool featured = false, bool visible = true, bool deleted = false)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            ImageUrl = imageurl;
            CategoryId = categoryId;
            Variants = variants;
            Featured = featured;
            Visible = visible;
            Deleted = deleted;

        }

    }
}
