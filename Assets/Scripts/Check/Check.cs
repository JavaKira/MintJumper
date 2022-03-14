using UnityEngine;
using UnityEngine.Events;

namespace Check
{
    public abstract class Check : MonoBehaviour
    {
        public UnityEvent onDone = new UnityEvent();
    }
}