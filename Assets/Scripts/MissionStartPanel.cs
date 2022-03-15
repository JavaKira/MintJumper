using UnityEngine;

public class MissionStartPanel : MonoBehaviour
{
    public static CampaignPoint.CampaignPointData LastPointData;

    public void Open(CampaignPoint point)
    {
        LastPointData = point.Data;
    }
}