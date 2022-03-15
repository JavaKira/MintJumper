using UnityEngine;
using UnityEngine.EventSystems;

namespace Behaviour.Button
{
    public class JumpPlayerButtonBehaviour : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private PlayerBehaviour playerBehaviour;

        private void TryJump()
        {
            playerBehaviour.TryJump();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            TryJump();
        }
    }
}