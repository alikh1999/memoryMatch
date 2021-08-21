using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Core;
using UnityEngine;

namespace Gameplay
{
    public class MonoCardMatcher : MonoBehaviour
    {
        public event Action<List<Card>> Matched;
        
        private bool _isMatching;
        public int MatchCount { get; set; }
        private List<Card> _cards = new List<Card>();
        
        public void TryShowCards(MonoCard monoCard)
        {
            if (!CanTrack(monoCard.Card))
                return;

            if (HasCardsMatchCountReached())
                StartCoroutine(TryMatch());
            
        }
        
        
        private IEnumerator TryMatch()
        {
            _isMatching = true;
            yield return new WaitForSeconds(1);
            
           if (AreMatch(_cards[0],_cards[1]))
                ShowCards();
           else
                HideCards();

            _isMatching = false;
            ClearCards();
        }
    

        private bool CanTrack(Card card)
        {
            if (_isMatching)
                return false;
            
            if (_cards.Contains(card))
                return false;
            
            card.Show();
            _cards.Add(card);
            return true;
        }
        
        private bool AreMatch(Card a, Card b)
        {
            return a.Content.IsEqual(b.Content);
        }

        private void ShowCards()
        {
            Matched?.Invoke(_cards.ToList());
            _cards.ForEach(c => c.Discard());
        }
        
        private void HideCards()
        {
            _cards.ForEach(c => c.Hide());
        }

        private void ClearCards()
        {
            _cards.Clear();
        }

        private bool HasCardsMatchCountReached()
        {
            return _cards.Count == MatchCount;
        }
    }
}