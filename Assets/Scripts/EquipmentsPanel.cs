using UnityEngine;
using UnityEngine.UI;

public class EquipmentsPanel : MonoBehaviour
{
    [SerializeField] private Image weaponSlot;

    public void Build()
    {
        var chosedWeapon = Campaign.GetEquipmentData().GetChosedWeapon();
        if (chosedWeapon != null)
            weaponSlot.sprite = chosedWeapon.GetComponent<SpriteRenderer>().sprite;
    }
}