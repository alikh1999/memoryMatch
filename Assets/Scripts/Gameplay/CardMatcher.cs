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
        public event Action<List<CardContainer>> OnMatched; 
        private List<CardContainer> _cards = new List<CardContainer>();

        public int MatchCount { get; set;}
        private bool _isMatching;
        public void Track(CardContainer card)
        {
            if (_isMatching)
                return;
            
            if (_cards.Contains(card))
                return;
            
            card.Show();
            _cards.Add(card);
            
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
                _cards.ForEach(c => c.Discard());
            }
            else
            {
                yield return new WaitForSeconds(1);
                _cards.ForEach(c => c.Hide());
            }

            _cards.Clear();
            _isMatching = false;
        }

        private bool Match()
        {
            var content = _cards.First().Content;
            return _cards.All(c => c.Content.IsEqual(content));
        }
    }
}