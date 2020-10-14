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
        public string TargetName { get; set; }

        /// <summary>
        /// 標的物數量
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 訂單類型
        /// </summary>
        public OrderType Type { get; set; }

        /// <summary>
        /// 成本
        /// </summary>
        public decimal Cost { get; set; }
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
