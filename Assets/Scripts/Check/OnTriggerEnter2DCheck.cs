using UnityEngine;

namespace Check
{
    public class OnTriggerEnter2DCheck : Check
    {
        [SerializeField] private GameObject waitedObject;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.Equals(waitedObject))
                onDone.Invoke();
        }
    }
}