using UnityEngine;

namespace Weapon
{
    public abstract class Weapon : MonoBehaviour
    {
        protected Mob Owner;

        public abstract void Attack();

        public void SetOwner(Mob mob)
        {
            Owner = mob;
        }

        public static Weapon GetByName(string name)
        {
            return Resources.Load<Weapon>(name);
        }
    }
}