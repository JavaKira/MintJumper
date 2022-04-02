using IO;

public static class Campaign
{
    private static CampaignData _data;
    private static EquipmentData _equipmentData;
    private static bool _loaded;

    public static CampaignData GetData()
    {
        return _data ??= LoadCampaignData();
    }
    
    public static EquipmentData GetEquipmentData()
    {
        return _equipmentData ??= LoadEquipmentData();
    }

    private static CampaignData LoadCampaignData()
    {
        var data = CampaignIO.Load();
        data.AddChangedListener(() => CampaignIO.Save(data));
        return data;
    }
    
    private static EquipmentData LoadEquipmentData()
    {
        var data = EquipmentIO.Load();
        data.AddChangedListener(() => EquipmentIO.Save(data));
        return data;
    }

    public static void ReloadData()
    {
        _data = CampaignIO.Load();
        _equipmentData = EquipmentIO.Load();
    }
}