using System.Collections;
using UnityEngine;

namespace Behaviour
{
    public class MeleeBeetleBehaviour : BeetleBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float reload;

        private bool _reloading;

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