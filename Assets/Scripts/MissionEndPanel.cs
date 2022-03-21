using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionEndPanel : MonoBehaviour
{
    private Star[] _stars;

    private void Awake()
    {
        _stars = GetComponentsInChildren<Star>();
    }

    public void Open(CampaignPoint.CampaignPointData data)
    {
        gameObject.SetActive(true);
        
        for (var i = 0; i < _stars.Length; i++)
        {
            _stars[i].UpdateState(i < data.Stars);
        }
    }
    
    public void Back()
    {
        Game.Instance.Resume();
        SceneManager.LoadScene("CampaignRoadScene");
    }
}