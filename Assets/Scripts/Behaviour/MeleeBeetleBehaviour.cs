using System.Collections;
using UnityEngine;

namespace Behaviour
{
    public class MeleeBeetleBehaviour : BeetleBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float reload;
        [SerializeField] private bool flipMove;

        private bool _reloading;

        protected override void FixedUpdateNoIdle()
        {
            var differenceX = (transform.position - Target.transform.position).normalized.x;
            Move(new Vector2(flipMove ? differenceX : -differenceX, 0));   
        }
        
        private void StartReloading()
        {
            StartCoroutine(Reloading());
        }

        private IEnumerator Reloading()
        {
            yield return new WaitForSeconds(reload);
            _reloading = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_reloading) return;
            
            var mob = other.gameObject.GetComponent<Mob>();
            if (Target == null || mob == null || mob != Target) return;
            
            mob.ApplyDamage(damage);
            _reloading = true;
            StartReloading();
        }
    }
}