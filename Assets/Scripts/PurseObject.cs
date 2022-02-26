using UnityEngine;

public class PurseObject : MonoBehaviour
{
    [SerializeField] private GameObject pursedObject;
    [SerializeField] private float softness;

    private void FixedUpdate()
    {
        var distance = transform.position - pursedObject.transform.position;
        transform.Translate(-(Vector2) distance / softness);
    }
}