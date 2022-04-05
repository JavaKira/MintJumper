using UnityEngine;

namespace Behaviour.Button
{
    [RequireComponent(typeof(UnityEngine.UI.Button))]
    public class DownPlayerButtonBehaviour : MonoBehaviour
    {
        [SerializeField] private PlayerBehaviour _playerBehaviour;
        private void Start()
        {
            GetComponent<UnityEngine.UI.Button>().onClick.AddListener(_playerBehaviour.OnDown.Invoke);
        }
    }
}