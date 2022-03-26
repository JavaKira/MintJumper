using System;
using System.Collections;
using UnityEngine;

namespace Behaviour
{
    public class PlayerBehaviour : MonoBehaviour
    {
        [SerializeField] private float speedMultiplier;
        [SerializeField] private float jumpMultiplier;
        [SerializeField] private float meleeDamage;
        [SerializeField] private AnimationCurve jumpCurve;

        private Animator _animator;
        private Vector2 _lastDirection;

        public bool isOnLadder { get; set; }

        private bool Grounded => IsGrounded();

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            var moveDirection = new Vector2();
            if (Input.GetKeyDown(KeyCode.Space)) TryJump();

            if (Input.GetKey(KeyCode.A)) moveDirection.x -= 1;

            if (Input.GetKey(KeyCode.D)) moveDirection.x += 1;

            if (!moveDirection.Equals(Vector2.zero))
                Move(moveDirection);
            
            _animator.SetBool("Walk", _lastDirection.normalized.x != 0);
            _lastDirection = new Vector2(0, 0);
        }

        public void Move(Vector2 direction)
        {
            var scale = transform.localScale;
            if (direction.x > 0)
                transform.localScale = new Vector3(1, scale.y, scale.z);

            if (direction.x < 0)
                transform.localScale = new Vector3(-1, scale.y, scale.z);

            transform.Translate(direction.x * speedMultiplier * Time.deltaTime,
                direction.y * speedMultiplier * Time.deltaTime, 0);
            _lastDirection = direction;
        }

        //"oh no" code ):<
        public void MeleeAttack()
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
            var transform1 = transform;
            var directionLeft = transform1.localScale.x < 0;
            var hit = Physics2D.Raycast(
                (Vector2) transform1.position + (directionLeft ? Vector2.left : Vector2.right) * 0.6f,
                directionLeft ? Vector2.left : Vector2.right);
            var mob = hit.rigidbody.GetComponent<Mob>();
            if (!(hit.distance < 0.01f) || mob == null) return;
            _animator.Play("Attack");
            mob.ApplyDamage(meleeDamage);
        }

        public void TryJump()
        {
            if (!Grounded)
                return;

            StartCoroutine(JumpCoroutine());
        }

        private IEnumerator JumpCoroutine()
        {
            int frame = default;
            while (frame < jumpCurve.length)
            {
                transform.Translate(0, jumpCurve[frame].value * jumpMultiplier * Time.fixedDeltaTime, 0);
                yield return new WaitForFixedUpdate();
                frame++;
            }

            yield return null;
        }

        private bool IsGrounded()
        {
            var position = transform.position;
            var hit = Physics2D.Raycast(new Vector2(position.x, position.y - 0.6f), Vector2.down, 1f);
            return hit.distance == 0;
        }
    }
}