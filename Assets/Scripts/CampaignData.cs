using System.Collections.Generic;
using UnityEngine.Events;

public class CampaignData
{
    private readonly List<CampaignPoint.CampaignPointData> _pointData = new List<CampaignPoint.CampaignPointData>();
    
    private readonly UnityEvent _changed = new UnityEvent();

    public void AddChangedListener(UnityAction action)
    {
        _changed.AddListener(action);
    }
    
    public void PutData(CampaignPoint.CampaignPointData data)
    {
        if (_pointData.Contains(data))
            _pointData.Remove(data);
        
        _pointData.Add(data);
        _changed.Invoke();
    }
    
    public CampaignPoint.CampaignPointData GetData(string title)
    {
        return _pointData.Find(data => data.CampaignPointTitle.Equals(title));
    }

    public List<CampaignPoint.CampaignPointData> GetData()
    {
        return new List<CampaignPoint.CampaignPointData>(_pointData);
    }
}