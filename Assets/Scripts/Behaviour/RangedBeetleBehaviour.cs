using UnityEngine;

namespace Behaviour
{
    public class RangedBeetleBehaviour : BeetleBehaviour
    {
        [SerializeField] private Weapon.Weapon weapon;
        private Mob _mob;

        private void Awake()
        {
            _mob = GetComponent<Mob>();
        }

        protected override void FixedUpdateNoIdle()
        {
            var transform1 = transform;
            var direction = -(transform1.position - Target.transform.position).normalized.x;
            var scale = transform1.localScale;
            if (direction > 0)
                transform.localScale = new Vector3(1, scale.y, scale.z);
        
            if (direction < 0)    
                transform.localScale = new Vector3(-1, scale.y, scale.z);
            
            weapon.SetOwner(_mob);
            weapon.Attack();
        }
    }
}