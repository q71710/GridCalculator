using System;

namespace Grid.Domain.Model
{
    /// <summary>
    /// 計算每格網格的價格差距
    /// </summary>
    public class PriceGapUnit : IUnit
    {
        public override void Execute(GridInfo gridInfo)
        {
            gridInfo.PriceGap = Math.Round((gridInfo.Setting.TopPrice - gridInfo.Setting.BottomPrice) / gridInfo.Setting.TotalGrid, gridInfo.Setting.RoundIndex);
        }
    }
}
