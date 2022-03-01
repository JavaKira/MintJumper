using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    public void Exit()
    {
        SceneManager.LoadScene("MainMenu");
        Game.Instance.Resume();
    }
}