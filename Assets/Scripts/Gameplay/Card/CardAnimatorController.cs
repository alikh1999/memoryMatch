using UnityEngine;

namespace Gameplay.Card
{
    public class CardAnimatorController : MonoBehaviour
    {
        private readonly int IsShowingHash = Animator.StringToHash("isShowing");
        private readonly int IsOnDiscardHash = Animator.StringToHash("onDiscard");
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>(); 
        }
        public void PlayShow()
        {
            _animator.SetBool(IsShowingHash, true);
        }

        public void PlayHide()
        {
            _animator.SetBool(IsShowingHash, false);
        }

        public void PlayDiscard()
        {
            _animator.SetTrigger(IsOnDiscardHash);
        }
    }
}