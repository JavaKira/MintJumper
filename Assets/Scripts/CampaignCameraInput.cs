using UnityEngine;

public class CampaignCameraInput : MonoBehaviour
{
    [SerializeField] private Vector2 xBounds;
    [SerializeField] private float speedMultiplier;

    private float _oldX;

    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) 
            transform.position -= new Vector3(1 * Time.deltaTime, 0) * speedMultiplier;
        
        if (Input.GetKey(KeyCode.D))
            transform.position += new Vector3(1 * Time.deltaTime, 0) * speedMultiplier;

        if (Input.touchCount != 0)
        {
            var touch = Input.GetTouch(Input.touchCount - 1);

            transform.position += new Vector3(-touch.deltaPosition.x * Time.deltaTime, 0) * speedMultiplier;
        }

        if (transform.position.x < xBounds.x)
            StopCameraMove();

        if (transform.position.x > xBounds.y)
            StopCameraMove();
        
        _oldX = transform.position.x;
    }

    private void StopCameraMove()
    {
        var transform1 = transform;
        var position = transform1.position;
        position = new Vector3(_oldX, position.y, position.z);
        transform1.position = position;
    }
}