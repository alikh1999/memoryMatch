using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gameplay.Card;
using UnityEngine;

namespace Gameplay
{
    public class CardMatcher : MonoBehaviour
    {
        public event Action<List<Card.MonoCard>> OnMatched; 
        private List<Card.MonoCard> _cards = new List<Card.MonoCard>();

        public int MatchCount { get; set;}
        private bool _isMatching;
        public void Track(Card.MonoCard monoCard)
        {
            if (_isMatching)
                return;
        
            if (_cards.Contains(monoCard))
                return;
            
            monoCard.Card.Show();
            _cards.Add(monoCard);
            
            if (_cards.Count != MatchCount)
                return;


            StartCoroutine(TryMatch());
        }

        private IEnumerator TryMatch()
        {
            _isMatching = true;
            if (Match())
            {
                yield return new WaitForSeconds(1);
                OnMatched?.Invoke(_cards.ToList());
                _cards.ForEach(c => c.Card.Discard());
            }
            else
            {
                yield return new WaitForSeconds(1);
                _cards.ForEach(c => c.Card.Hide());
            }

            _cards.Clear();
            _isMatching = false;
        }

        private bool Match()
        {
            var content = _cards.First().Card.Content;
            return _cards.All(c => c.Card.Content.IsEqual(content));
        }
    }
}