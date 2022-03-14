using UnityEngine;

public class BeetleBehaviour : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    [SerializeField] private float triggeredSpeedMultiplier;
    [SerializeField] private float idleDirectionChangeTime;

    private Mob _target;
    private bool _idle = true;
    private float _directionTime;
    /*left or right*/
    private bool _directionLeft; 
    
    private void FixedUpdate()
    {
        if (_idle)
        {
            var hit = Physics2D.Raycast(
                (Vector2) transform.position + (_directionLeft ? Vector2.left : Vector2.right) * 0.6f,
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
        else
        {
            Move(new Vector2(-(transform.position - _target.transform.position).normalized.x, 0));    
        }
    }

    private void Move(Vector2 direction)
    {
        var scale = transform.localScale;
        if (direction.x > 0)
            transform.localScale = new Vector3(1, scale.y, scale.z);
        
        if (direction.x < 0)    
            transform.localScale = new Vector3(-1, scale.y, scale.z);

        var checkedSpeedMultiplier = _idle ? speedMultiplier : triggeredSpeedMultiplier;
        transform.Translate(direction.x * checkedSpeedMultiplier * Time.deltaTime, direction.y * checkedSpeedMultiplier * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBehaviour>() == null) return;
        
        _target = other.GetComponent<Mob>();
        _idle = false;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<PlayerBehaviour>() == null) return;
        
        _target = null;
        _idle = true;
    }
}