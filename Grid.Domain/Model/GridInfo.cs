namespace Grid.Domain.Model
{
    public class GridInfo
    {
        //設定
        public GridSetting Setting { get; set; }

        public decimal PriceGap { get; set; }

        //計算結果、掛單資訊
        public PendingOrder PendingOrders { get; set; }
    }
}
