using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SceneOpenButtonBehaviour : MonoBehaviour
{
    [SerializeField] private string sceneName;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            SceneManager.LoadScene(sceneName);
        });
    }
}