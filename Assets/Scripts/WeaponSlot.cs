using System;
using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    [SerializeField] private Weapon.Weapon _weapon;
    
    public Weapon.Weapon Weapon { get; private set; }

    private void Awake()
    {
        Build(_weapon);
    }

    public Weapon.Weapon Build(Weapon.Weapon weapon)
    {
        Weapon = Instantiate(weapon, transform);
        return Weapon;
    }

    public void RemoveWeapon()
    {
        Destroy(Weapon);
    }
}