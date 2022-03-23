using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionStartPanel : MonoBehaviour
{
    public static CampaignPoint.CampaignPointData LastPointData;

    [SerializeField] private TMP_Text title;
    [SerializeField] private Button startButton;
    [SerializeField] private Star[] stars;

    private UnityAction _lastButtonAction;

    public void Open(CampaignPoint point)
    {
        gameObject.SetActive(true);
        LastPointData = point.Data;
        title.text = point.Data.CampaignPointTitle;
        for (var i = 0; i < stars.Length; i++)
        {
            stars[i].UpdateState(i < point.Data.Stars);
        }
        
        if (_lastButtonAction != null)
            startButton.onClick.RemoveListener(_lastButtonAction);
        Mission.Preset = point.MissionType;
        _lastButtonAction = () => SceneManager.LoadScene(point.MissionType.SceneName);
        startButton.onClick.AddListener(_lastButtonAction);
    }
}