using System;
using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float lifetime = 5;
    [SerializeField] private ParticleSystem destroyEffect;

    private float _time;
    private Mob _owner;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var mob = other.gameObject.GetComponent<Mob>();
        if (_owner.Enemy)
        {
            if (mob != null && !mob.name.Equals(_owner.name) && !mob.Enemy)
                mob.ApplyDamage(damage);
        }
        else
            if (mob != null && !mob.name.Equals(_owner.name))
                mob.ApplyDamage(damage);

        if (mob != null && mob.name.Equals(_owner.name))
            return;
        
        Destroy();
    }

    private void Destroy()
    {
        var effect = Instantiate(destroyEffect);
        var position = transform.position;
        effect.transform.position = new Vector3(position.x, position.y, position.z);
        StartCoroutine(StartDestroyEffect(effect, 1));
        Destroy(gameObject);
    }

    public IEnumerator StartMove(Vector2 direction, float speedMultiplier)
    {
        while (_time <= lifetime)
        {
            _time += Time.deltaTime;
            _rigidbody.velocity += new Vector2(
                direction.x * Time.deltaTime * speedMultiplier, 
                direction.y * Time.deltaTime * speedMultiplier
            );
            yield return null;
        }
        
        Destroy();
    }
    
    private static IEnumerator StartDestroyEffect(ParticleSystem particle, float delay)
    {
        particle.Play();
        yield return new WaitForSeconds(delay);
        Destroy(particle.gameObject);
    }

    public void SetOwner(Mob mob)
    {
        _owner = mob;
    }
}