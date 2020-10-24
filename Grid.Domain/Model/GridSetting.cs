using System;

namespace Grid.Domain.Model
{
    public class GridSetting
    {
        private decimal startPrice;
        private decimal topPrice;
        private decimal bottomPrice;
        private decimal marketPrice;
        private decimal oneGridPriceGap;
        private int roundIndex;

        public GridSetting(CoinType buyCoin)
        {
            BuyCoin = buyCoin;
            SetCoinIndex();
        }

        /// <summary>
        /// 拿來交易的幣種標的
        /// </summary>
        public CoinType BuyCoin { get; private set; }

        /// <summary>
        /// 起始價格
        /// </summary>
        public decimal StartPrice 
        {
            get => startPrice;
            set => startPrice = Math.Round(value, roundIndex);
        }

        private void SetCoinIndex()
        {
            switch(BuyCoin)
            {
                case CoinType.ETH:
                case CoinType.XMR:
                    roundIndex = 2;
                    break;
                case CoinType.IOTA:
                case CoinType.UNI:
                case CoinType.BTC:
                    roundIndex = 4;
                    break;
                default:
                    roundIndex = 2;
                    break;
            }
        }

        /// <summary>
        /// 網格最高價
        /// </summary>
        public decimal TopPrice
        {
            get => topPrice;
            set => topPrice = Math.Round(value, roundIndex);
        }

        /// <summary>
        /// 網格最底價
        /// </summary>
        public decimal BottomPrice
        {
            get => bottomPrice;
            set => bottomPrice = Math.Round(value, roundIndex);
        }

        /// <summary>
        /// 網格總數量(偶數)
        /// </summary>
        public int TotalGrid { get; set; }

        /// <summary>
        /// 交易手續費
        /// </summary>
        public decimal TradeFee { get; set; }

        /// <summary>
        /// 市場最新成交價格
        /// </summary>
        public decimal MarketPrice
        {
            get => marketPrice;
            set => marketPrice = Math.Round(value, roundIndex);
        }

        public decimal PriceGap
        {
            get => oneGridPriceGap;
            set => oneGridPriceGap = Math.Round(value, roundIndex);
        }
    }
}
