namespace Grid.Domain.Model
{
    public class GridSetting
    {
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
        /// 網格總數量(偶數)
        /// </summary>
        public int TotalGrid { get; set; }

        /// <summary>
        /// 交易手續費
        /// </summary>
        public decimal TradeFee { get; set; }
    }
}
