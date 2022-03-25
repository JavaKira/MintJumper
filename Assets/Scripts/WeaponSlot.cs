using System;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public Weapon.Weapon Weapon { get; private set; }

    private void Awake()
    {
        Build(Campaign.GetEquipmentData().GetChosedWeapon());
    }

    private void Build(Weapon.Weapon weapon)
    {
        Weapon = Instantiate(weapon, transform);
        Weapon.SetOwner(GetComponentInParent<Mob>());
    }

    public void RemoveWeapon()
    {
        Destroy(Weapon);
    }
}