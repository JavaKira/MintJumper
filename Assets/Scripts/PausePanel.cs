using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public void ResumeButton()
    {
        Game.Instance.Resume();
    }
    
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        Game.Instance.Resume();
    }
}