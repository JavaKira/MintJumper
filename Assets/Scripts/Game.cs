using System;
using UnityEngine;
using UnityEngine.Events;

public class Game : MonoBehaviour
{
    public static readonly UnityEvent OnStart = new UnityEvent();
    public static Game Instance;
    private bool _pause;

    public GameStats Stats;

    private void Awake()
    {
        Instance = this;
        Stats = new GameStats();
    }

    private void Start()
    {
        OnStart.Invoke();    
    }

    public void Pause()
    {
        _pause = true;
        Time.timeScale = 0;
    }

    public void Resume()
    {
        _pause = false;
        Time.timeScale = 1;
    }

    public bool IsPause()
    {
        return _pause;
    }
}