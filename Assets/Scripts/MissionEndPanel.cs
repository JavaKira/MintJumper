using UnityEngine;
using UnityEngine.SceneManagement;

public class MissionEndPanel : MonoBehaviour
{
    public void Back()
    {
        Game.Instance.Resume();
        SceneManager.LoadScene("CampaignRoadScene");
    }
}