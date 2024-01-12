namespace Product.WebAPI.Controllers.Response
{
    /// <summary>
    /// 返回信息
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }

        public bool Success { get; set; }

        public string? Message { get; set; }

    }
}
