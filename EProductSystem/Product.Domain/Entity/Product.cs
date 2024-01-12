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
    public class Product
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public Category? Category { get; set; }

        public Guid CategoryId { get; set; }

        public List<ProductVariant> Variants { get; set; }

        public bool Featured { get; set; }

        public bool Visible { get; set; }

        public bool Deleted { get; set; }

        public Product()
        {

        }

        public Product(string title, string description, string imageurl, Guid categoryId, List<ProductVariant> variants, bool featured = false, bool visible = true, bool deleted = false)
        {
            Id = Guid.NewGuid();
            Title   = title;
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
