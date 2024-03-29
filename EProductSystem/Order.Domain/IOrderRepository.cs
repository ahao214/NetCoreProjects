﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain
{
    public interface IOrderRepository
    {
        Task<Order.Domain.Entity.Order> GetOrderDetail(Guid orderId, Guid userId);
        Task<List<Order.Domain.Entity.OrderItem>> GetOrderDetails(Guid orderId);
        Task<List<Order.Domain.Entity.Order>> GetOrders(Guid userId);
    }
}
