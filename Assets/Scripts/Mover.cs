using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float speedMultiplier;

    private void FixedUpdate()
    {
        transform.Translate(1 * speedMultiplier * Time.fixedDeltaTime, 0, 0);
    }
}