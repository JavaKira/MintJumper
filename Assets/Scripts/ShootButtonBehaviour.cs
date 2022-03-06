using UnityEngine;
using UnityEngine.EventSystems;

public class ShootButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private WeaponSlot slot;
    
    private bool _touched;

    private void FixedUpdate()
    {
        if (_touched)
            slot.Weapon.Attack();
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