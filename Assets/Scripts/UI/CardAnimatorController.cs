using UnityEngine;

namespace Gameplay.Core
{
    public class CardAnimatorController : MonoBehaviour
    {
        private readonly int IsShowingHash = Animator.StringToHash("isShowing");
        private readonly int IsOnDiscardHash = Animator.StringToHash("onDiscard");
        private Animator _animator;

        private void Start()
        {
            _animator = GetComponent<Animator>(); 
            var monoCard = GetComponent<MonoCard>();

            monoCard.Card.Shown += PlayShow;
            monoCard.Card.Hidden += PlayHide;
            monoCard.Card.Discarded += PlayDiscard;
        }
        private void PlayShow()
        {
            _animator.SetBool(IsShowingHash, true);
        }

        private void PlayHide()
        {
            _animator.SetBool(IsShowingHash, false);
        }

        private void PlayDiscard()
        {
            _animator.SetTrigger(IsOnDiscardHash);
        }
    }
}