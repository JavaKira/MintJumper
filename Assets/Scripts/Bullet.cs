using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private float lifetime = 5;
    [SerializeField] private ParticleSystem destroyEffect;

    private float _time;
    private Mob _owner;

    private void OnCollisionEnter2D(Collision2D other)
    {
        var mob = other.gameObject.GetComponent<Mob>();
        if (mob != null && !mob.Equals(_owner))
            mob.ApplyDamage(damage);
        
        if (mob != null && mob.Equals(_owner))
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
            transform.Translate(
                direction.x * Time.deltaTime * speedMultiplier, 
                direction.y * Time.deltaTime * speedMultiplier,
                0
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