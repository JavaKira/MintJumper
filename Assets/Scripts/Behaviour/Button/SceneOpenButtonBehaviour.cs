using UnityEngine;
using UnityEngine.SceneManagement;

namespace Behaviour.Button
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class SceneOpenButtonBehaviour : MonoBehaviour
    {
        [SerializeField] private string sceneName;

        private void Awake()
        {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene(sceneName);
            });
        }
    }
}