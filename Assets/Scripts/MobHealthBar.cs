using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MobHealthBar : MonoBehaviour
{
    [SerializeField] private Mob mob;

    private IEnumerable<MobHealthBarHeart> _gameObjects;
    
    private void Start()
    {
        _gameObjects = GetComponentsInChildren<MobHealthBarHeart>();
        mob.healthChanged.AddListener(UpdateHealth);
    }

    private void UpdateHealth(float health)
    {
        var iterations = 0;
        foreach (var obj in _gameObjects)
        {
            iterations++;
            obj.UpdateState(mob.MaxHealth / _gameObjects.Count() * iterations <= health);
        }
    }
}