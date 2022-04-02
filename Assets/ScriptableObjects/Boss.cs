using System;
using Behaviour;
using UnityEngine;

namespace ScriptableObjects
{
    [RequireComponent(typeof(Mob))]
    public class Boss : MonoBehaviour
    {
        public Mob Mob { get; private set; }

        private void Awake()
        {
            Mob = GetComponent<Mob>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.GetComponent<PlayerBehaviour>() == null) return;
            FindObjectOfType<BossHealthBar>(true).Open(this);
            Mob.healthChanged.AddListener(MobHealthChanged);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.GetComponent<PlayerBehaviour>() != null)
                FindObjectOfType<BossHealthBar>(true).Close();
        }

        private void MobHealthChanged(float health)
        {
            if (health <= 0)
            {
                FindObjectOfType<BossHealthBar>(true).Close(); 
            }
        }

        private void OnDisable()
        {
            Mob.healthChanged.RemoveListener(MobHealthChanged);
        }
    }
}