using System.Collections.Generic;
using UnityEngine.Events;

public class EquipmentData
{
    private readonly List<string> _unlockedWeaponNames = new List<string>();
    private Weapon.Weapon _chosedWeapon;
    
    private readonly UnityEvent _changed = new UnityEvent();

    public void AddChangedListener(UnityAction action)
    {
        _changed.AddListener(action);
    }

    public Weapon.Weapon GetChosedWeapon()
    {
        return _chosedWeapon;
    }
    
    public void ChoseWeapon(Weapon.Weapon weapon)
    {
        if (weapon != null && _unlockedWeaponNames.Contains(weapon.name))
            _chosedWeapon = weapon;

        _changed.Invoke();
    }

    public void UnlockWeapon(Weapon.Weapon weapon)
    {
        UnlockWeapon(weapon.name);
    }
    
    public void UnlockWeapon(string name)
    {
        if (_unlockedWeaponNames.Contains(name)) return;
        _unlockedWeaponNames.Add(name);
        _changed.Invoke();
    }

    public List<string> GetUnlockedWeapons()
    {
        return new List<string>(_unlockedWeaponNames);
    }
}