using System;
using UnityEngine;
using UnityEngine.Events;

namespace Check
{
    public class PositionCheck : Check
    {
        private enum Method
        {
            Bigger, Less, Equals
        }

        [SerializeField] private Method method;
        [SerializeField] private Vector2 position;

        private void FixedUpdate()
        {
            switch (method)
            {
                case Method.Bigger: 
                    if (transform.position.x > position.x && transform.position.y > position.y)
                        onDone.Invoke();
                    break;
                case Method.Less: 
                    if (transform.position.x < position.x && transform.position.y < position.y)
                        onDone.Invoke();
                    break;
                case Method.Equals: 
                    if (transform.position.Equals(position))
                        onDone.Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        
        }
    }
}