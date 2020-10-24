using System;
using System.Collections.Generic;

namespace Grid.Domain.Model
{
    public class GridResult
    {
        /// <summary>
        /// 每個單的價格差距值
        /// </summary>
        public decimal PriceGap { get; set; }

        public List<Order> BuyOrders { get; set; }

        public List<Order> SellOrders { get; set; }
    }
}
