using System;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static Game Instance;

    private bool _pause;

    private void Awake()
    {
        Instance = this;
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