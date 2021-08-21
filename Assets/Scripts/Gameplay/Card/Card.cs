using System;
using UnityEngine;
using UnityEngine.Events;


namespace Gameplay.Core
{
    //todo: content should be passed as ctr arg
    public class Card
    {
        private CardState _state = CardState.Hiding;

        private bool _isDiscarded;

        public event Action MyEvent;
        public CardContent Content { get; }
        public event Action Shown;
        public event Action Hidden;
        public event Action Discarded;

        public Card(CardContent content)
        {
            Content = content;
        }
        
        public void Discard()
        {
            if (_isDiscarded)
                return;

            Discarded?.Invoke();
            _isDiscarded = true;
        }

        public void Hide()
        {
            if (_state != CardState.Showing)
                return;
            
            Hidden?.Invoke();
            _state = CardState.Hiding;
        }

        public void Show()
        {
            if (_state != CardState.Hiding) return;
            
            Shown?.Invoke();
            _state = CardState.Showing;
        }
    }
}
