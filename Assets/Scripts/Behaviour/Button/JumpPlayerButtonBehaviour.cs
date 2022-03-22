using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Behaviour.Button
{
    public class JumpPlayerButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private PlayerBehaviour playerBehaviour;

        private Rigidbody2D _playerRigidbody2D;
        private bool _pressed;

        private void Start()
        {
            _playerRigidbody2D = playerBehaviour.GetComponent<Rigidbody2D>();
        }

        private void TryJump()
        {
            playerBehaviour.TryJump();
        }

        private void FixedUpdate()
        {
            if (!_pressed && playerBehaviour.isOnLadder)
                _playerRigidbody2D.gravityScale = 1;
            
            if (!_pressed || !playerBehaviour.isOnLadder) return;
            _playerRigidbody2D.gravityScale = 0;
            _playerRigidbody2D.velocity = new Vector2();
            playerBehaviour.Move(Vector2.up);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            _pressed = true;
            if (playerBehaviour.isOnLadder)
            {
                _playerRigidbody2D.gravityScale = 0;
                _playerRigidbody2D.velocity = new Vector2();
                playerBehaviour.Move(Vector2.up);
            }
            else
                TryJump();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _pressed = false;
        }
    }
}