using System;

namespace Grid.Domain.Model
{
    /// <summary>
    /// Grid計算器介面
    /// 更動 任何一項，都能產出結果
    /// </summary>
    public interface IGridCalculator
    {
        /// <summary>
        /// 取得計算結果
        /// </summary>
        /// <returns></returns>
        (Exception exception, GridInfo gridInfo) GetResult(GridInfo info);
    }
}