using System;
using System.Collections.Generic;

namespace Grid.Domain.Model.Unit
{
    public class OrderUnit : IUnit
    {
        public override void Execute(GridInfo gridInfo)
        {
            var amountOfBuyOrder = (int)Math.Round((gridInfo.Setting.MarketPrice - gridInfo.Setting.BottomPrice) / gridInfo.PriceGap);

            var amountOfSellOrder = (int)Math.Round((gridInfo.Setting.TopPrice - gridInfo.Setting.MarketPrice) / gridInfo.PriceGap);

            List<Order> sellOrders = new List<Order>();

            for (int index = 1; index <= amountOfSellOrder; index++)
            {
                var price = gridInfo.Setting.MarketPrice + (index * gridInfo.PriceGap);

                if (price > gridInfo.Setting.TopPrice || price <= gridInfo.Setting.MarketPrice) continue;

                sellOrders.Add(new Order(gridInfo.Setting.BuyCoin, OrderType.PendingSell)
                {
                    Price = price
                });
            }

            List<Order> buyOrders = new List<Order>();

            for (int index = 1; index <= amountOfBuyOrder; index++)
            {
                var price = gridInfo.Setting.MarketPrice - (index * gridInfo.PriceGap);

                if (price < gridInfo.Setting.BottomPrice) continue;

                buyOrders.Add(new Order(gridInfo.Setting.BuyCoin, OrderType.PendingBuy)
                {
                    Price = price
                });
            }

            gridInfo.PendingOrders = new PendingOrder
            {
                BuyOrders = buyOrders,
                SellOrders = sellOrders,
            };
        }
    }
}
