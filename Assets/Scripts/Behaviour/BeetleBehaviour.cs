using UnityEngine;

namespace Behaviour
{
    public class BeetleBehaviour : MonoBehaviour
    {
        [SerializeField] private float speedMultiplier;
        [SerializeField] private float triggeredSpeedMultiplier;
        [SerializeField] private float idleDirectionChangeTime;
        [SerializeField] private float rayOffset;

        protected Mob Target;
        
        private bool _idle = true;
        private float _directionTime;
        /*left or right*/
        private bool _directionLeft; 
    
        public void FixedUpdate()
        {
            if (_idle)
                FixedUpdateIdle();
            else
                FixedUpdateNoIdle();
        }

        protected virtual void FixedUpdateIdle()
        {
            var hit = Physics2D.Raycast(
                (Vector2) transform.position + (_directionLeft ? Vector2.left : Vector2.right) * rayOffset,
                _directionLeft ? Vector2.left : Vector2.right);
            if (hit.distance == 0)
                _directionLeft = !_directionLeft;
            
            _directionTime += Time.fixedDeltaTime;
            if (_directionTime > idleDirectionChangeTime)
            {
                _directionLeft = !_directionLeft;
                _directionTime = 0;
            }
            
            Move(_directionLeft ? Vector2.left : Vector2.right);
        }

        protected virtual void FixedUpdateNoIdle()
        {
            
        }

        protected void Move(Vector2 direction)
        {
            var scale = transform.localScale;
            if (direction.x > 0)
                transform.localScale = new Vector3(1, scale.y, scale.z);
        
            if (direction.x < 0)    
                transform.localScale = new Vector3(-1, scale.y, scale.z);

            var checkedSpeedMultiplier = _idle ? speedMultiplier : triggeredSpeedMultiplier;
            transform.Translate(direction.x * checkedSpeedMultiplier * Time.deltaTime, direction.y * checkedSpeedMultiplier * Time.deltaTime, 0);
        }

        protected virtual void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerBehaviour>() == null) return;
        
            Target = other.GetComponent<Mob>();
            _idle = false;
        }

        protected virtual void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<PlayerBehaviour>() == null) return;
        
            Target = null;
            _idle = true;
        }
    }
}