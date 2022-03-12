using System;
using System.Collections.Generic;
using UnityEngine.Events;

public class GameStats
{
    private readonly Dictionary<string, int> _mobsKilled = new Dictionary<string, int>();
    private readonly Dictionary<string, int> _mobsLive = new Dictionary<string, int>();
    
    public readonly UnityEvent Changed = new UnityEvent();

    public void AddMobKilled(Mob mob)
    {
        if (!_mobsKilled.ContainsKey(mob.name))
            _mobsKilled.Add(mob.name, 0);
        
        _mobsKilled[mob.name] += 1;
        Changed.Invoke();
    }
    
    public void RemoveMobKilled(Mob mob)
    {
        if (!_mobsKilled.ContainsKey(mob.name))
            throw new ArgumentException("could not find mob " + mob.name + " in mob killed stat");
        
        _mobsKilled[mob.name] -= 1;
        Changed.Invoke();
    }
    
    public void AddMobLive(Mob mob)
    {
        if (!_mobsLive.ContainsKey(mob.name))
            _mobsLive.Add(mob.name, 0);
        
        _mobsLive[mob.name] += 1;
        Changed.Invoke();
    }
    
    public void RemoveMobLive(Mob mob)
    {
        if (!_mobsLive.ContainsKey(mob.name))
            throw new ArgumentException("could not find mob " + mob.name + " in mob live stat");
        
        _mobsLive[mob.name] -= 1;
        Changed.Invoke();
    }

    public int GetMobKilled(string name)
    {
        return _mobsKilled[name];
    }
    
    public int GetMobsLive(string name)
    {
        return _mobsLive[name];
    }
}