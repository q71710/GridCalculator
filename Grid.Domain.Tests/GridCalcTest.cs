using System;
using Grid.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grid.Domain.Tests
{
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
        public void 計算掛單價差距值1()
        {
            GridSetting setting = new GridSetting
            {
                TopPrice = 0.281m,
                BottomPrice = 0.2207m,
                TotalGrid = 20
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);
            Assert.AreEqual(0.003m, actual.result.PriceGap);
        }

        [TestMethod]
        public void 計算掛單價差距值2()
        {
            GridSetting setting = new GridSetting
            {
                TopPrice = 410m,
                BottomPrice = 350m,
                TotalGrid = 22,
                MarketPrice = 390
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);
            Assert.AreEqual(2.7273m, actual.result.PriceGap);
            Assert.AreEqual(15, actual.result.AmountOfBuyOrder);
            Assert.AreEqual(8, actual.result.AmountOfSellOrder);
        }

        [TestMethod]
        public void 計算掛單價差距值3()
        {
            GridSetting setting = new GridSetting
            {
                TopPrice = 10000m,
                BottomPrice = 5000m,
                TotalGrid = 5,
                MarketPrice = 6500m
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);
            Assert.AreEqual(1000m, actual.result.PriceGap);
            Assert.AreEqual(2, actual.result.AmountOfBuyOrder);
            Assert.AreEqual(4, actual.result.AmountOfSellOrder);
        }

        [TestMethod]
        public void 計算掛單價差距值3_1()
        {
            GridSetting setting = new GridSetting
            {
                TopPrice = 10000m,
                BottomPrice = 5000m,
                TotalGrid = 5,
                MarketPrice = 5500m
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);
            Assert.AreEqual(1000m, actual.result.PriceGap);
            Assert.AreEqual(1, actual.result.AmountOfBuyOrder);
            Assert.AreEqual(5, actual.result.AmountOfSellOrder);
        }

        [TestMethod]
        public void 計算掛單價差距值4()
        {
            GridSetting setting = new GridSetting
            {
                TopPrice = 0.29m,
                BottomPrice = 0.24m,
                TotalGrid = 25
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);
            Assert.AreEqual(0.002m, actual.result.PriceGap);
        }

        [TestMethod]
        public void 計算掛單價差距值5()
        {
            GridSetting setting = new GridSetting
            {
                TopPrice = 139m,
                BottomPrice = 110m,
                TotalGrid = 29
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);
            Assert.AreEqual(1m, actual.result.PriceGap);
        }

        [TestMethod]
        public void 計算掛單價差距值6()
        {
            GridSetting setting = new GridSetting
            {
                TopPrice = 100m,
                BottomPrice = 10m,
                TotalGrid = 10
            };

            gridCalc.SetValue(setting);
            var actual = gridCalc.GetResult();

            Assert.IsNull(actual.exception);
            Assert.AreEqual(9m, actual.result.PriceGap);
        }
    }
}
