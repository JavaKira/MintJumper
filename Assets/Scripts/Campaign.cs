using IO;

public static class Campaign
{
    private static CampaignData _data;
    private static bool _loaded;

    public static CampaignData GetData()
    {
        return _data ??= LoadCampaignData();
    }

    private static CampaignData LoadCampaignData()
    {
        var data = CampaignIO.Load();
        data.AddChangedListener(() => CampaignIO.Save(data));
        return data;
    }
}