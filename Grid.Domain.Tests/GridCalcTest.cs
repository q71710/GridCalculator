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
        public void 整數_市價接近下限不產買單()
        {
            GridInfo info = new GridInfo
            {
                Setting = new GridSetting(CoinType.BTC)
                {
                    TopPrice = 10000m,
                    BottomPrice = 5000m,
                    TotalGrid = 5,
                    MarketPrice = 5500m
                }
            };

            var result = gridCalc.GetResult(info);
            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.gridInfo);
            Assert.AreEqual(1000m, result.gridInfo.PriceGap);

            var actual = result.gridInfo.PendingOrders;
            var expected = new PendingOrder
            {
                BuyOrders = new List<Order> { },
                SellOrders = new List<Order>
                {
                    new Order(CoinType.BTC, OrderType.PendingSell) { Price = 6500m },
                    new Order(CoinType.BTC, OrderType.PendingSell) { Price = 7500m },
                    new Order(CoinType.BTC, OrderType.PendingSell) { Price = 8500m },
                    new Order(CoinType.BTC, OrderType.PendingSell) { Price = 9500m }
                }
            };

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void 整數_市價接近下限產少量買單()
        {
            GridInfo info = new GridInfo
            {
                Setting = new GridSetting(CoinType.BTC)
                {
                    TopPrice = 10000m,
                    BottomPrice = 5000m,
                    TotalGrid = 5,
                    MarketPrice = 6200m
                },
                PendingOrders = null
            };

            var result = gridCalc.GetResult(info);
            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.gridInfo);
            Assert.AreEqual(1000m, result.gridInfo.PriceGap);

            var actual = result.gridInfo.PendingOrders;
            var expected = new PendingOrder
            {
                BuyOrders = new List<Order>
                {
                    new Order(CoinType.BTC, OrderType.PendingBuy) { Price = 5200m },
                },
                SellOrders = new List<Order>
                {
                    new Order(CoinType.BTC, OrderType.PendingSell) { Price = 7200m },
                    new Order(CoinType.BTC, OrderType.PendingSell) { Price = 8200m },
                    new Order(CoinType.BTC, OrderType.PendingSell) { Price = 9200m }
                }
            };

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void 整數_市價接近上限產少量賣單()
        {
            GridInfo info = new GridInfo
            {
                Setting = new GridSetting(CoinType.BTC)
                {
                    TopPrice = 10000m,
                    BottomPrice = 5000m,
                    TotalGrid = 5,
                    MarketPrice = 8800m
                },
            };

            var result = gridCalc.GetResult(info);
            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.gridInfo);
            Assert.AreEqual(1000m, result.gridInfo.PriceGap);

            var actual = result.gridInfo.PendingOrders;
            var expected = new PendingOrder
            {
                BuyOrders = new List<Order>
                {
                    new Order(CoinType.BTC, OrderType.PendingBuy) { Price = 7800m },
                    new Order(CoinType.BTC, OrderType.PendingBuy) { Price = 6800m },
                    new Order(CoinType.BTC, OrderType.PendingBuy) { Price = 5800m },
                },
                SellOrders = new List<Order>
                {
                    new Order(CoinType.BTC, OrderType.PendingSell) { Price = 9800m }
                }
            };

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void 整數_市價接近上限不產賣單()
        {
            GridInfo info = new GridInfo
            {
                Setting = new GridSetting(CoinType.BTC)
                {
                    TopPrice = 10000m,
                    BottomPrice = 5000m,
                    TotalGrid = 5,
                    MarketPrice = 9800m
                },
                PendingOrders = null
            };

            var result = gridCalc.GetResult(info);
            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.gridInfo);
            Assert.AreEqual(1000m, result.gridInfo.PriceGap);

            var actual = result.gridInfo.PendingOrders;
            var expected = new PendingOrder
            {
                BuyOrders = new List<Order>
                {
                    new Order(CoinType.BTC, OrderType.PendingBuy) { Price = 8800m },
                    new Order(CoinType.BTC, OrderType.PendingBuy) { Price = 7800m },
                    new Order(CoinType.BTC, OrderType.PendingBuy) { Price = 6800m },
                    new Order(CoinType.BTC, OrderType.PendingBuy) { Price = 5800m }
                },
                SellOrders = new List<Order> { }
            };

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void 小數後2_市價接近下限產少量買單()
        {
            GridInfo info = new GridInfo
            {
                Setting = new GridSetting(CoinType.BTC)
                {
                    TopPrice = 10000m,
                    BottomPrice = 5000m,
                    TotalGrid = 7,
                    MarketPrice = 6200m
                }
            };

            var result = gridCalc.GetResult(info);
            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.gridInfo);
            Assert.AreEqual(714.29m, result.gridInfo.PriceGap);

            var actual= result.gridInfo.PendingOrders;
            var expected = new PendingOrder
            {
                BuyOrders = new List<Order>
                {
                    new Order(CoinType.BTC, OrderType.PendingBuy) { Price = 5485.71m },
                },
                SellOrders = new List<Order>
                {
                    new Order(CoinType.BTC, OrderType.PendingSell){ Price = 6914.29m },
                    new Order(CoinType.BTC, OrderType.PendingSell){ Price = 7628.58m },
                    new Order(CoinType.BTC, OrderType.PendingSell){ Price = 8342.87m },
                    new Order(CoinType.BTC, OrderType.PendingSell){ Price = 9057.16m },
                    new Order(CoinType.BTC, OrderType.PendingSell){ Price = 9771.45m }
                }
            };

            actual.Should().BeEquivalentTo(expected);
        }

        [TestMethod]
        public void 小數後4_市價接近下限產少量買單()
        {
            GridInfo info = new GridInfo
            {
                Setting = new GridSetting(CoinType.UNI)
                {
                    TopPrice = 3.6m,
                    BottomPrice = 2.6m,
                    TotalGrid = 11,
                    MarketPrice = 2.9m
                }
            };

            var result = gridCalc.GetResult(info);
            Assert.IsNull(result.exception);
            Assert.IsNotNull(result.gridInfo);
            Assert.AreEqual(0.0909m, result.gridInfo.PriceGap);

            var actual = result.gridInfo.PendingOrders;
            var expected = new PendingOrder
            {
                BuyOrders = new List<Order>
                {
                    new Order(CoinType.UNI, OrderType.PendingBuy) { Price = 2.8091m },
                    new Order(CoinType.UNI, OrderType.PendingBuy) { Price = 2.7182m },
                    new Order(CoinType.UNI, OrderType.PendingBuy) { Price = 2.6273m }
                },
                SellOrders = new List<Order>
                {
                    new Order(CoinType.UNI, OrderType.PendingSell) { Price = 2.9909m },
                    new Order(CoinType.UNI, OrderType.PendingSell) { Price = 3.0818m },
                    new Order(CoinType.UNI, OrderType.PendingSell) { Price = 3.1727m },
                    new Order(CoinType.UNI, OrderType.PendingSell) { Price = 3.2636m },
                    new Order(CoinType.UNI, OrderType.PendingSell) { Price = 3.3545m },
                    new Order(CoinType.UNI, OrderType.PendingSell) { Price = 3.4454m },
                    new Order(CoinType.UNI, OrderType.PendingSell) { Price = 3.5363m }
                }
            };

            actual.Should().BeEquivalentTo(expected);
        }


        //[TestMethod]
        //public void 小數後1_市價接近下限產少量買單_2()
        //{
        //    GridSetting setting = new GridSetting(CoinType.UNI)
        //    {
        //        TopPrice = 3.6m,
        //        BottomPrice = 2.6m,
        //        TotalGrid = 11,
        //        MarketPrice = 2.9m
        //    };

        //    gridCalc.SetValue(setting);
        //    var actual = gridCalc.GetResult();

        //    Assert.IsNull(actual.exception);

        //    GridResult expected = new GridResult
        //    {
        //        PriceGap = 0.0909m,
        //        BuyOrders = new List<Order>
        //        {
        //            new Order { Coin = CoinType.UNI, Type = OrderType.PendingBuy, Price = 2.8091m },
        //            new Order { Coin = CoinType.UNI, Type = OrderType.PendingBuy, Price = 2.7182m },
        //            new Order { Coin = CoinType.UNI, Type = OrderType.PendingBuy, Price = 2.6273m },
        //        },
        //        SellOrders = new List<Order>
        //        {
        //            new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 2.9909m },
        //            new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.0818m },
        //            new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.1727m },
        //            new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.2636m },
        //            new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.3545m },
        //            new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.4454m },
        //            new Order { Coin = CoinType.UNI, Type = OrderType.PendingSell, Price = 3.5363m }
        //        }
        //    };

        //    actual.result.Should().BeEquivalentTo(expected);
        //}
    }
}
