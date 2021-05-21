using System;
using UnityEngine;

namespace Gameplay
{
    public class Countdown : MonoBehaviour
    {
        public int Counter
        {
            get => _counter;
            private set => _counter = value;
        }

        public event Action<int> OnCountDown;
        public event Action OnReachedZero;
        
        [SerializeField]
        private Timer _timer;

        [SerializeField] private int _counter;

        private void Start()
        {
            _timer.OnTicked += OnTicked;
        }

        private void OnTicked()
        {
            Counter--;
            if (Counter == 0)
            {
                OnReachedZero?.Invoke();
                _timer.Stop();
            }
            

            OnCountDown?.Invoke(Counter);
        }

        public void Start(int count)
        {
            if (count <= 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            
            Counter = count;
            _timer.Restart();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}