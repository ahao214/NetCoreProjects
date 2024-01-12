using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entity
{
    /// <summary>
    /// 类别
    /// </summary>
    public class Category
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public bool Visible { get; set; }
        public bool Deleted { get; set; }

        public Category()
        {

        }

        public Category(string name, string url, bool visible = true, bool deleted = false)
        {
            Id = Guid.NewGuid();
            Name = name;
            Url = url;
            Visible = visible;
            Deleted = deleted;
        }
    }
}
