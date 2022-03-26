using UnityEngine;

public class WeaponSlot : MonoBehaviour
{
    public bool Empty;
    public Weapon.Weapon Weapon { get; private set; }

    private void Awake()
    {
        Build(Campaign.GetEquipmentData().GetChosedWeapon());
    }

    private void Build(Weapon.Weapon weapon)
    {
        Empty = weapon == null;
        Weapon = Instantiate(weapon, transform);
        Weapon.SetOwner(GetComponentInParent<Mob>());
    }

    public void RemoveWeapon()
    {
        Destroy(Weapon);
        Empty = true;
    }
}