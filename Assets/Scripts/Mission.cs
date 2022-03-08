using UnityEngine;

public class Mission : MonoBehaviour
{
    public void End()
    {
        Game.Instance.Pause();
        FindObjectOfType<MissionEndPanel>(true).gameObject.SetActive(true);
    }
}