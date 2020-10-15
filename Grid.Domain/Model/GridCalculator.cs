using System;

namespace Grid.Domain.Model
{
    public class GridCalculator : ICalculator
    {
        private GridSetting setting;

        public void Set(GridSetting gridSetting)
        {
            setting = gridSetting;
        }


        public decimal CalcPriceGap()
        {
            var midValue = setting.TopPrice - setting.BottomPrice;

            var result = Math.Round(midValue / setting.TotalGrid, 3);

            return result;
        }
    }
}
