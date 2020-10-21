using System;

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
                var result = Calc();

                return (null, result);
            }
            catch(Exception ex)
            {
                return (ex, null);
            }
        }

        public void SetValue(GridSetting gridSetting) 
            => setting = gridSetting;

        private GridResult Calc()
        {
            var 高低價格間距 = setting.TopPrice - setting.BottomPrice;

            var 單一格下單價格差距 = 高低價格間距 / setting.TotalGrid;

            return new GridResult { PriceGap = 單一格下單價格差距 };
        }
    }

    
}
