using UnityEngine;
using UnityEngine.Events;


namespace Gameplay.Card
{
    public class CardContainer : MonoBehaviour
    {
        public UnityEvent<CardContent> ContentSetEvent;
        public CardContent Content
        {
            get => _content;
            set
            {
                _content = value;
                ContentSetEvent.Invoke(value);
            } 
        }

        private CardContent _cardContent;
        private CardAnimatorController _animator;
        private CardContent _content;

        private void Awake()
        {
            _animator = GetComponent<CardAnimatorController>();
        }
        public void Show()
        {
           _animator.PlayShow();
        }

        public void Hide()
        {
           _animator.PlayHide();
        }
        
        public void Discard()
        {
            _animator.PlayDiscard();
        }
    }
}
