using Grid.Domain.Model.Unit;
using System;

namespace Grid.Domain.Model
{
    public class GridCalc : IGridCalculator
    {
        public (Exception exception, GridInfo gridInfo) GetResult(GridInfo info)
        {
            BaseGridUnit baseUnit = new BaseGridUnit(info);
            baseUnit.SetUnit(new PriceGapUnit());
            baseUnit.SetUnit(new OrderUnit());

            return (null, info);
        }
    }
}
