using System;
using System.Collections;
using UnityEngine;

namespace Gameplay
{
    public class Timer : MonoBehaviour
    {
        public event Action OnTicked;
        public void Restart()
        {
            Stop();
            StartCoroutine(Tick());
        }

        public void Stop()
        {
            StopAllCoroutines();
        }

        private IEnumerator Tick()
        {
            while (true)
            {
                yield return new WaitForSeconds(1);
                OnTicked?.Invoke();
            }
         
        }
    }
}
