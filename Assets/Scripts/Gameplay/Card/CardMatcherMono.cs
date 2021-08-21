using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Card;
using UnityEngine;

namespace Gameplay
{
    public class CardMatcherMono : MonoBehaviour
    {
        
        private readonly CardMatcher _cardMatcher = new CardMatcher();

        public ICardMatcher CardMatcher => _cardMatcher;

        public int MatchCount
        {
            set => _cardMatcher.MatchCount = value;
        }
        
        public void TryShowCards(Card.MonoCard monoCard)
        {
            if (!_cardMatcher.CanTrack(monoCard))
                return;
            
            if (!_cardMatcher.HasCardsMatchCountReached())
                return;
            
            StartCoroutine(TryMatch());
        }

        private IEnumerator TryMatch()
        {
            _cardMatcher.IsMatching = true;
            yield return new WaitForSeconds(1);
            if (_cardMatcher.AreMatch())
                _cardMatcher.ShowCards();
            else
                _cardMatcher.HideCards();

            _cardMatcher.IsMatching = false;
            _cardMatcher.ClearCards();
        }
    }
}