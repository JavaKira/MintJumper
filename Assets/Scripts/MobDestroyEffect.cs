using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class MobDestroyEffect : MonoBehaviour
{
    [SerializeField] private float lifetime;
    
    public UnityEvent onStart = new UnityEvent();

    public MobDestroyEffect Instantiate(Mob mob)
    {
        var effect = Instantiate(this);
        var transform1 = mob.transform;
        var position = transform1.position;
        effect.transform.position = new Vector3(position.x, position.y, position.z);
        return effect;
    }
    
    public void StartEffect()
    {
        onStart.Invoke();
        StartCoroutine(DestroyCoroutine());
    }

    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }
}