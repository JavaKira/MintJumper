using UnityEngine;

public class PausePanelInput : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Escape)) return;
            
        if (Game.Instance.IsPause())
            Game.Instance.Resume();
        else
            Game.Instance.Pause();

        pausePanel.SetActive(!pausePanel.activeSelf);
    }
}