namespace Grid.Domain.Model
{
    /// <summary>
    /// 訂單類別
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 標的物名稱
        /// </summary>
        public CoinType Coin { get; set; }

        /// <summary>
        /// 訂單類型
        /// </summary>
        public OrderType Type { get; set; }

        /// <summary>
        /// 標的物數量
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 價格
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 與上一單差異百分比
        /// </summary>
        public decimal Percent { get; set; }
    }

    /// <summary>
    /// 掛單類型
    /// </summary>
    public enum OrderType
    {
        /// <summary>
        /// 掛賣單
        /// </summary>
        PendingSell,

        /// <summary>
        /// 掛買單
        /// </summary>
        PendingBuy
    }
}
