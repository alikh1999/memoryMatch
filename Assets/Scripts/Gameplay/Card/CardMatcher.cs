using System;
using System.Collections.Generic;
using System.Linq;

namespace Gameplay.Card
{

    public interface ICardMatcher
    {
        event Action<List<MonoCard>> OnMatched;
    }
    public class CardMatcher : ICardMatcher
    {
        public event Action<List<MonoCard>> OnMatched;
        public bool IsMatching { get; set; }
        public int MatchCount { get; set; }
        
        private List<MonoCard> _cards = new List<MonoCard>();

        public bool CanTrack(MonoCard monoCard)
        {
            if (IsMatching)
                return false;
            
            if (_cards.Contains(monoCard))
                return false;
            
            monoCard.Card.Show();
            _cards.Add(monoCard);
            return true;
        }
        
        public bool AreMatch()
        {
            var content = _cards.First().Card.Content;
            return _cards.All(c => c.Card.Content.IsEqual(content));
        }

        public void ShowCards()
        {
            OnMatched?.Invoke(_cards.ToList());
            _cards.ForEach(c => c.Card.Discard());
        }
        
        public void HideCards()
        {
            _cards.ForEach(c => c.Card.Hide());
        }

        public void ClearCards()
        {
            _cards.Clear();
        }

        public bool HasCardsMatchCountReached()
        {
            return _cards.Count == MatchCount;
        }
    }
}