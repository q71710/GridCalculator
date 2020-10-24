using System;
using System.Collections.Generic;
using System.Linq;

namespace Grid.Domain.Model
{
    public class GridCalc : IGridCalc
    {
        private GridSetting setting = null;

        public (Exception exception, GridResult result) GetResult()
        {
            if (setting == null) return (new Exception("未設置計算資訊"), null);

            try
            {
                GetGap();

                var gResult = Calc();

                return (null, gResult);
            }
            catch(Exception ex)
            {
                return (ex, null);
            }
        }

        public void SetValue(GridSetting gridSetting) 
            => setting = gridSetting;

        public void GetGap()
        {
            var 高低價格間距 = setting.TopPrice - setting.BottomPrice;

            var 單一格下單價格差距 = 高低價格間距 / setting.TotalGrid;

            setting.PriceGap = 單一格下單價格差距;
        }

        private GridResult Calc()
        {
            var amountOfBuyOrder = (int)Math.Round((setting.MarketPrice - setting.BottomPrice) / setting.PriceGap);

            var amountOfSellOrder = (int)Math.Round((setting.TopPrice - setting.MarketPrice) / setting.PriceGap);

            List<Order> sellOrders = new List<Order>();

            for (int index = 1; index <= amountOfSellOrder; index++)
            {
                var price = setting.MarketPrice + (index * setting.PriceGap);

                if (price > setting.TopPrice || price <= setting.MarketPrice) continue;

                sellOrders.Add(new Order
                {
                    Coin = setting.BuyCoin,
                    Type = OrderType.PendingSell,
                    Price = price
                });
            }

            List<Order> buyOrders = new List<Order>();

            for (int index = 1; index <= amountOfBuyOrder; index++)
            {
                var price = setting.MarketPrice - (index * setting.PriceGap);

                if (price < setting.BottomPrice) continue;

                buyOrders.Add(new Order
                {
                    Coin = setting.BuyCoin,
                    Type = OrderType.PendingBuy,
                    Price = price
                });
            }

            return new GridResult 
            {
                PriceGap = setting.PriceGap,
                BuyOrders = buyOrders,
                SellOrders = sellOrders,
            };
        }
    }    
}
