using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private float time;
    [SerializeField] private bool startAtAwake;
    
    public UnityEvent onDone = new UnityEvent();

    private void Awake()
    {
        if (startAtAwake)
            StartTimer();
    }

    public void StartTimer()
    {
        StartCoroutine(Start());
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(time);
        onDone.Invoke();
    }
}