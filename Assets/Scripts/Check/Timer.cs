using System.Collections;
using UnityEngine;

namespace Check
{
    public class Timer : Check
    {
        [SerializeField] private float time;
        [SerializeField] private bool startAtAwake;

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
}