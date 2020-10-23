using System;
using System.Collections.Generic;

namespace Grid.Domain.Model
{
    public class GridResult
    {
        private decimal priceGap;

        /// <summary>
        /// 每個單的價格差距值
        /// </summary>
        public decimal PriceGap 
        {
            get => priceGap;
            set => priceGap = Math.Round(value, 4);
        }

        public int AmountOfBuyOrder { get; set; }

        public int AmountOfSellOrder { get; set; }

        public IEnumerable<Order> BuyOrders { get; private set; }

        public IEnumerable<Order> SellOrders { get; set; }
    }
}
