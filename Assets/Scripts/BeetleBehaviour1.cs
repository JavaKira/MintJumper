using UnityEngine;

public class BeetleBehaviour1 : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;

    private void FixedUpdate()
    {
        transform.Translate(1 * speedMultiplier * Time.fixedDeltaTime, 0, 0);
    }
}