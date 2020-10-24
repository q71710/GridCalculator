using FluentAssertions;
using Grid.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Grid.Domain.Tests
{
    /// <summary>
    /// 計算掛單資訊
    /// </summary>
    [TestClass]
    public class GridCalcTest
    {
        private GridCalc gridCalc;

        [TestInitialize]
        public void Init()
        {
            gridCalc = new GridCalc();
        }

        [TestMethod]
        public void 小數後2_市價接近下限不產買單()
        {
            GridSetting setting = new GridSetting(CoinType.BTC)
            {
                TopPrice = 10000m,
                BottomPrice = 5000m,
                TotalGrid = 5,
                MarketPrice = 5500m
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);

            GridResult expected = new GridResult
            {
                PriceGap = 1000m,
                BuyOrders = new List<Order> { },
                SellOrders = new List<Order>
                {
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingSell, Price = 6500m },
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingSell, Price = 7500m },
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingSell, Price = 8500m },
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingSell, Price = 9500m },
                }
            };

            actual.result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void 小數後2_市價接近下限產少量買單()
        {
            GridSetting setting = new GridSetting(CoinType.BTC)
            {
                TopPrice = 10000m,
                BottomPrice = 5000m,
                TotalGrid = 5,
                MarketPrice = 6200m
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);

            GridResult expected = new GridResult
            {
                PriceGap = 1000m,
                BuyOrders = new List<Order> 
                {
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingBuy, Price = 5200m },
                },
                SellOrders = new List<Order>
                {
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingSell, Price = 7200m },
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingSell, Price = 8200m },
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingSell, Price = 9200m }
                }
            };

            actual.result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void 小數後2_市價接近上限產少量賣單()
        {
            GridSetting setting = new GridSetting(CoinType.BTC)
            {
                TopPrice = 10000m,
                BottomPrice = 5000m,
                TotalGrid = 5,
                MarketPrice = 8800m
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);

            GridResult expected = new GridResult
            {
                PriceGap = 1000m,
                BuyOrders = new List<Order>
                {
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingBuy, Price = 7800m },
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingBuy, Price = 6800m },
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingBuy, Price = 5800m },
                },
                SellOrders = new List<Order>
                {
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingSell, Price = 9800m },
                }
            };

            actual.result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void 小數後2_市價接近上限不產賣單()
        {
            GridSetting setting = new GridSetting(CoinType.BTC)
            {
                TopPrice = 10000m,
                BottomPrice = 5000m,
                TotalGrid = 5,
                MarketPrice = 9800m
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);

            GridResult expected = new GridResult
            {
                PriceGap = 1000m,
                BuyOrders = new List<Order>
                {
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingBuy, Price = 8800m },
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingBuy, Price = 7800m },
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingBuy, Price = 6800m },
                    new Order { Coin = CoinType.BTC, Type = OrderType.PendingBuy, Price = 5800m },
                },
                SellOrders = new List<Order> { }
            };

            actual.result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void 小數後1_市價接近下限產少量買單()
        {
            GridSetting setting = new GridSetting(CoinType.UNI)
            {
                TopPrice = 3.6m,
                BottomPrice = 2.6m,
                TotalGrid = 10,
                MarketPrice = 2.9m
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);

            GridResult expected = new GridResult
            {
                PriceGap = 0.1m,
                BuyOrders = new List<Order>
                {
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingBuy, Price = 2.8m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingBuy, Price = 2.7m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingBuy, Price = 2.6m },
                },
                SellOrders = new List<Order>
                {
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.0m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.1m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.2m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.3m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.4m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.5m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.6m }

                }
            };

            actual.result.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void 小數後1_市價接近下限產少量買單_2()
        {
            GridSetting setting = new GridSetting(CoinType.UNI)
            {
                TopPrice = 3.6m,
                BottomPrice = 2.6m,
                TotalGrid = 11,
                MarketPrice = 2.9m
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);

            GridResult expected = new GridResult
            {
                PriceGap = 0.0909m,
                BuyOrders = new List<Order>
                {
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingBuy, Price = 2.8091m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingBuy, Price = 2.7182m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingBuy, Price = 2.6273m },
                },
                SellOrders = new List<Order>
                {
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 2.9909m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.0818m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.1727m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.2636m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.3545m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.4454m },
                    new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.5363m }
                }
            };

            actual.result.Should().BeEquivalentTo(expected);
        }
    }
}
