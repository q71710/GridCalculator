namespace Grid.Domain.Model
{
    class JobInfo
    {
        //設定
        GridSetting gridSetting;

        //計算結果、掛單資訊
        PendingOrder gridResult;

        //交易紀錄
        Record record;
    }
}
