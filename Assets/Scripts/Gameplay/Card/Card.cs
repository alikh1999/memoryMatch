using System;
using UnityEngine;
using UnityEngine.Events;


namespace Gameplay.Card
{
    public class Card
    {
        private CardContent _content;
        private CardState _state = CardState.Hiding;

        private bool _isDiscarded;
        public CardContent Content
        {
            get => _content;
            set
            {
                _content = value;
                ContentSet?.Invoke(value);
            }
        }

        public GameObject GameObject { get; }

        public event Action<CardContent> ContentSet;
        public event Action Shown;
        public event Action Hidden;
        public event Action Discarded;

        public Card()
        {
        }
        
        public Card(GameObject gameObject)
        {
            gameObject = gameObject;
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
