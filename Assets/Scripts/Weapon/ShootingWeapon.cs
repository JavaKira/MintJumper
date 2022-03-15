using UnityEngine;

namespace Weapon
{
    public class ShootingWeapon : Weapon
    {
        [SerializeField] private Animation attackAnimation;
        [SerializeField] private Bullet bulletType;
        [SerializeField] private float bulletSpeedMultiplier = 1f;
        [SerializeField] private Vector2 bulletSpawnOffset;
    
        public override void Attack()
        {
            if (attackAnimation.isPlaying) return;
            var transform1 = transform;
            CreateBullet(transform1.position, transform1.lossyScale.x > 0.5f ? Vector2.left : Vector2.right);
            attackAnimation.Play();
        }

        private void CreateBullet(Vector2 position, Vector2 direction)
        {
            var bullet = Instantiate(bulletType);
            bullet.transform.position = transform.lossyScale.x > 0.5f
                ? new Vector3(position.x + -bulletSpawnOffset.x, position.y + -bulletSpawnOffset.y)
                : new Vector3(position.x + bulletSpawnOffset.x, position.y + bulletSpawnOffset.y);
            bullet.StartCoroutine(bullet.StartMove(direction, bulletSpeedMultiplier));
            bullet.SetOwner(Owner);
        }
    }
}