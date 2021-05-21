﻿using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Gameplay.Card
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

        public List<CardContainer> GenerateSet(CardSetGenerationArgs args)
        {
            _args = args;
            var contents = GenerateContents(args.OriginalCount);

            var cards = new List<CardContainer>();
            foreach (var c in contents)
            {
                for (int i = 0; i < args.MatchCount; i++)
                {
                    var card = GenerateCard(c);
                    cards.Add(card);
                }
            }

            return cards.OrderBy(c => GUID.Generate()).ToList();
        }
        
        private CardContainer GenerateCard(CardNumberContent content)
        {
            var card = _cardFactory.Create();
            card.Content = content;
            return card;
        }

        protected abstract List<CardNumberContent> GenerateContents(int count);
    }
}