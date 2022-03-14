using UnityEngine;

namespace Behaviour
{
    public class BackgroundBeetleBehaviour : MonoBehaviour
    {
        [SerializeField] private Vector2 xBounds;
        [SerializeField] private float speedMultiplier;

        private void FixedUpdate()
        {
            transform.Translate(1 * speedMultiplier * Time.fixedDeltaTime, 0, 0);

            if (transform.position.x > xBounds.y)
                Return();
        
            TryJump();
        }
    
        private void Return()
        {
            var transform1 = transform;
            var position = transform1.position;
            position = new Vector3(xBounds.x, position.y, position.z);
            transform1.position = position;
        }

        private void TryJump()
        {
            if (!IsGrounded())
                return;
        
            transform.Translate(0, 1, 0);
        }

        private bool IsGrounded()
        {
            var position = transform.position;
            var hit = Physics2D.Raycast(new Vector2(position.x, position.y - 0.6f), Vector2.down, 1f);
            return hit.distance == 0;
        }
    }
}