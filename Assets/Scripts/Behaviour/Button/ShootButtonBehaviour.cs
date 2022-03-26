using UnityEngine;
using UnityEngine.EventSystems;

namespace Behaviour.Button
{
    public class ShootButtonBehaviour : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [SerializeField] private PlayerBehaviour player;
        [SerializeField] private WeaponSlot slot;

        private bool _touched;

        private void FixedUpdate()
        {
            if (!_touched) return;
            if (slot.Empty) 
                player.MeleeAttack();
            else
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
}