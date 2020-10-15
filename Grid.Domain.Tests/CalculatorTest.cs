using System;
using Grid.Domain.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Grid.Domain.Tests
{
    [TestClass]
    public class CalculatorTest
    {
        private GridSetting setting;
        private GridCalculator calculator;

        [TestInitialize]
        public void Init()
        {
            calculator = new GridCalculator();
            setting = new GridSetting();

            calculator.Set(setting);
        }

        ///// <summary>
        ///// 每格籌碼數量
        ///// </summary>
        //public decimal BodyAmount { get; set; }

        [TestMethod]
        public void CalcPriceGap1()
        {
            setting.StartPrice = 0.2578m;
            setting.TopPrice = 0.281m;
            setting.BottomPrice = 0.2207m;
            setting.TotalGrid = 20;

            var actual = calculator.CalcPriceGap();

            Assert.AreEqual(0.003m, actual);
        }

        [TestMethod]
        public void CalcPriceGap2()
        {
            setting.StartPrice = 0.2578m;
            setting.TopPrice = 0.281m;
            setting.BottomPrice = 0.21m;
            setting.TotalGrid = 20;

            var actual = calculator.CalcPriceGap();

            Assert.AreEqual(0.004m, actual);
        }
    }
}
