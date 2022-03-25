using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectSlot : MonoBehaviour
{
    [SerializeField] private Weapon.Weapon weapon;
    [SerializeField] private Button button;
    [SerializeField] private Image icon;

    private void Awake()
    {
        button.interactable = Campaign.GetEquipmentData().GetUnlockedWeapons().Contains(weapon.name);
        icon.sprite = weapon.GetComponent<SpriteRenderer>().sprite;
    }
}