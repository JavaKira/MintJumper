using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;
    
    private bool Grounded => IsGrounded();

    private void Update()
    {
        var moveDirection = new Vector2();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection.x -= 1;
        }
        
        if (Input.GetKey(KeyCode.D))
        {
            moveDirection.x += 1;
        }

        Move(moveDirection);
    }

    public void Move(Vector2 direction)
    {
        var scale = transform.localScale;
        if (direction.x > 0)
            transform.localScale = new Vector3(1, scale.y, scale.z);
        
        if (direction.x < 0)    
            transform.localScale = new Vector3(-1, scale.y, scale.z);
        
        transform.Translate(direction.x * speedMultiplier * Time.deltaTime, direction.y * speedMultiplier * Time.deltaTime, 0);
    }

    public void TryJump()
    {
        if (!Grounded)
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