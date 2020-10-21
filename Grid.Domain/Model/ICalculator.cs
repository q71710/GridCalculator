using System;

namespace Grid.Domain.Model
{
    public interface ICalculator
    {
        decimal CalcPriceGap();
    }

    /// <summary>
    /// Grid計算器介面
    /// 更動 任何一項，都能產出結果
    /// </summary>
    public interface IGridCalc
    {

        /// <summary>
        /// 賦值
        /// </summary>
        /// <param name="gridSetting"></param>
        void SetValue(GridSetting gridSetting);

        /// <summary>
        /// 取得計算結果
        /// </summary>
        /// <returns></returns>
        (Exception exception, GridResult result) GetResult();
    }
}
