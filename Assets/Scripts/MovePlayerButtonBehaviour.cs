using UnityEngine;
using UnityEngine.EventSystems;

public class MovePlayerButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerBehaviour playerBehaviour;
    [SerializeField] private Vector2 direction;

    private bool _touched;
    
    private void FixedUpdate()
    {
        if (_touched)
            Move();
    }
    
    private void Move()
    { 
        playerBehaviour.Move(direction);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _touched = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _touched = false;
    }
}