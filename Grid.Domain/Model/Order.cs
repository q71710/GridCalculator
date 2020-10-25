namespace Grid.Domain.Model
{
    /// <summary>
    /// 訂單類別
    /// </summary>
    public class Order
    {
        public Order(CoinType coinType, OrderType orderType)
        {
            Coin = coinType;
            Type = orderType;
        }

        private int roundIndex;

        /// <summary>
        /// 標的物名稱
        /// </summary>
        public CoinType Coin { get; private set; }

        /// <summary>
        /// 訂單類型
        /// </summary>
        public OrderType Type { get; private set; }

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

        private void SetCoinIndex()
        {
            switch (Coin)
            {
                case CoinType.ETH:
                case CoinType.XMR:
                    roundIndex = 2;
                    break;
                case CoinType.BTC:
                case CoinType.UNI:
                case CoinType.IOTA:
                    roundIndex = 4;
                    break;
                default:
                    roundIndex = 2;
                    break;
            }
        }
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
