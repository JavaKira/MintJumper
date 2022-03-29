using UnityEngine;
using UnityEngine.Events;

public class Mob : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private MobDestroyEffect destroyEffect;
    [SerializeField] private bool enemy;

    private float _health;
    private bool _killed;

    public UnityEvent<float> healthChanged = new UnityEvent<float>();

    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public bool Enemy => enemy;

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
        //i use _killed, reason it unity Destroy destroys gameObject not immediate, its make possible to Dead() called many times
        if (!_killed)
        {
            Game.Instance.Stats.RemoveMobLive(this);
            Game.Instance.Stats.AddMobKilled(this);
        }
        if (destroyEffect != null)
            destroyEffect.Instantiate(this).StartEffect();
        Destroy(gameObject);
        _killed = true;
    }
    
    public static Mob GetByName(string name)
    {
        return Resources.Load<Mob>(name);
    }
}