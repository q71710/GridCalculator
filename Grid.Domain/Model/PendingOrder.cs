using System;
using System.Collections.Generic;

namespace Grid.Domain.Model
{
    public class PendingOrder
    {
        public List<Order> BuyOrders { get; set; }

        public List<Order> SellOrders { get; set; }
    }
}
