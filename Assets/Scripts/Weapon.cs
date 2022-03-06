using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected Mob Owner;
    
    public abstract void Attack();
    
    public void SetOwner(Mob mob)
    {
        Owner = mob;
    }
}