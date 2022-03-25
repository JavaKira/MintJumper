using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelectPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text description;
    [SerializeField] private Image icon;
    [SerializeField] private Weapon.Weapon defaultWeapon;

    private Weapon.Weapon _currentWeapon;

    private void Start()
    {
        SetWeapon(defaultWeapon);
    }

    public void SetWeapon(Weapon.Weapon weapon)
    {
        _currentWeapon = weapon;
        description.text = weapon.name;
        icon.sprite = defaultWeapon.GetComponent<SpriteRenderer>().sprite;
    }

    public void ApplyChose()
    {
        if (_currentWeapon != null)
            Campaign.GetEquipmentData().ChoseWeapon(_currentWeapon);
    }
} 