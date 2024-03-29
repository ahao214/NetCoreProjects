﻿namespace Payment.WebAPI.Request
{
    public record PaymentRequest(Guid productId, string title, string imageUrl, Guid productTypeId, string productType, decimal price, int quantity);
}
