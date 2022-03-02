using UnityEngine;
using UnityEngine.Events;

public class OnTriggerEnter2DCheck : MonoBehaviour
{
    [SerializeField] private GameObject waitedObject;
    
    public UnityEvent onDone = new UnityEvent();

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.Equals(waitedObject))
            onDone.Invoke();
    }
}