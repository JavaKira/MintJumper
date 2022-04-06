using System.Collections;
using UnityEngine;

namespace Behaviour
{
    public class MeleeBeetleBehaviour : BeetleBehaviour
    {
        [SerializeField] private float damage;
        [SerializeField] private float reload;
        [SerializeField] private bool flipMove;
        [SerializeField] private GameObject reaction;

        private bool _reloading;
        private bool _reacted;

        protected override void FixedUpdateNoIdle()
        {
            if (!_reacted)
            {
                if (!reaction.activeSelf)
                    StartCoroutine(Reaction());
                
                return;
            }
            
            MoveToTarget();
        }
        
        private void StartReloading()
        {
            StartCoroutine(Reloading());
        }

        private void MoveToTarget()
        {
            var differenceX = (transform.position - Target.transform.position).normalized.x;
            Move(new Vector2(flipMove ? differenceX : -differenceX, 0));  
        }

        private IEnumerator Reloading()
        {
            yield return new WaitForSeconds(reload);
            _reloading = false;
        }

        private IEnumerator Reaction()
        {
            MoveToTarget();
            reaction.SetActive(true);
            yield return new WaitForSeconds(0.2f);
            reaction.SetActive(false);
            _reacted = true;
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

        protected override void OnTriggerExit2D(Collider2D other)
        {
            base.OnTriggerExit2D(other);
            if (other.GetComponent<PlayerBehaviour>() == null) return;
            _reacted = false;
            reaction.SetActive(false);
        }
    }
}