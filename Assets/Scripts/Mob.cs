using UnityEngine;

public class Mob : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float _health;
    
    private void Awake()
    {
        Heal();
    }

    private void Heal()
    {
        _health = maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        _health -= damage;
        
        if (_health <= 0)
            Dead();
    }

    private void Dead()
    {
        Destroy(gameObject);
    }
}