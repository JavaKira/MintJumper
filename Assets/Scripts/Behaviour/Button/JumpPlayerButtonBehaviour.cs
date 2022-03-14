using UnityEngine;
using UnityEngine.EventSystems;

namespace Behaviour.Button
{
    public class JumpPlayerButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private PlayerBehaviour playerBehaviour;
    
        private bool _touched;

        private void FixedUpdate()
        {
            if (_touched)
                TryJump();
        }

        private void TryJump()
        {
            playerBehaviour.TryJump();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _touched = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _touched = false;
        }
    }
}