using UnityEngine;
using UnityEngine.Events;

public class KeyListener : MonoBehaviour
{
    [SerializeField] private KeyCode keyCode;
    
    public UnityEvent onKeyDown = new UnityEvent();

    private void Update()
    {
        if (Input.GetKeyDown(keyCode))
            onKeyDown.Invoke();
    }
}