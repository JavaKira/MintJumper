using System;
using UnityEngine;
using UnityEngine.Events;

public class Mob : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float _health;
    
    public UnityEvent<float> healthChanged = new UnityEvent<float>();

    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    private void Awake()
    {
        Heal();
        Game.OnStart.AddListener(() => Game.Instance.Stats.AddMobLive(this));
    }

    private void Heal()
    {
        _health = maxHealth;
        healthChanged.Invoke(_health);
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        
        if (_health <= 0)
            Dead();
        healthChanged.Invoke(_health);
    }

    private void Dead()
    {
        Game.Instance.Stats.RemoveMobLive(this);
        Game.Instance.Stats.AddMobKilled(this);
        Destroy(gameObject);
    }
}