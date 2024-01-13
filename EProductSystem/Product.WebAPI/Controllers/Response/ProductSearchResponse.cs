namespace Product.WebAPI.Controllers.Response
{
    /// <summary>
    /// 分页
    /// </summary>
    public class ProductSearchResponse
    {
        public List<Domain.Entity.Product> Products { get; set; } = new List<Domain.Entity.Product>();
        // 总页数
        public int Pages { get; set; }
        // 当前页数
        public int CurrentPage { get; set; }

    }
}
