namespace Grid.Domain.Model
{
    public class GridSetting : ICalculator
    {
        public GridSetting()
        {
        }

        /// <summary>
        /// 起始價格
        /// </summary>
        public decimal StartPrice { get; set; }

        /// <summary>
        /// 網格最高價
        /// </summary>
        public decimal TopPrice { get; set; }

        /// <summary>
        /// 網格最底價
        /// </summary>
        public decimal BottomPrice { get; set; }

        /// <summary>
        /// 網格總數量
        /// </summary>
        public int TotalGrid { get; set; }

        /// <summary>
        /// 網格間價格差距
        /// </summary>
        public decimal PriceGap { get; private set; }

        /// <summary>
        /// 每格籌碼數量
        /// </summary>
        public decimal BodyAmount { get; set; }

        public void Calc()
        {
            var midValue = TopPrice - BottomPrice;

            var PriceGap = midValue / TotalGrid;
        }
    }
}
