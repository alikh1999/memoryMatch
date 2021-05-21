using System;
using Gameplay;
using UnityEngine;

namespace UI
{
    public class TimerView : MonoBehaviour
    {
        [SerializeField]
        private Countdown countdown;
        [SerializeField]
        private Label _label;

        private void Start()
        {
            countdown.OnCountDown += UpdateTime;
        }

        public void UpdateTime(int Time)
        => _label.SetText(Time.ToString());
    }
}
