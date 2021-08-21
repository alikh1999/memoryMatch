using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Gameplay.Core
{
    
    public abstract class BaseCardsSetGenerator : MonoBehaviour, ICardSetGenerator
    {
        private ICardFactory _cardFactory;
        private CardSetGenerationArgs _args;
        
        [Inject]
        private void Init(ICardFactory cardFactory)
        {
            _cardFactory = cardFactory;
        }

        public List<MonoCard> GenerateSet(CardSetGenerationArgs args)
        {
            _args = args;
            var contents = GenerateContents(args.OriginalCount);

            var cards = new List<MonoCard>();
            foreach (var c in contents)
            {
                for (int i = 0; i < args.MatchCount; i++)
                {
                    var card = GenerateCard(c);
                    cards.Add(card);
                }
            }

            return cards.OrderBy(c => Guid.NewGuid()).ToList();
        }
        
        private MonoCard GenerateCard(CardNumberContent content)
        {
            var monoCard = _cardFactory.Create();
            monoCard.Card = new Card(content);
            return monoCard;
        }

        protected abstract List<CardNumberContent> GenerateContents(int count);
    }
}