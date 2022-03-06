using System;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public Weapon Weapon { get; private set; }
    
    public Weapon Build(Weapon weapon)
    {
        Weapon = Instantiate(weapon, transform);
        return Weapon;
    }

    public void RemoveWeapon()
    {
        Destroy(Weapon);
    }
}