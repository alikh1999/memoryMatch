using Gameplay.Card;
using ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Gameplay
{
    public class Game : MonoBehaviour
    {
        [SerializeField] 
        [Range(2,6)]
        private int _cardsMatchCount;
        [SerializeField]
        private Transform _cardsContainer;
        [SerializeField]
        private Countdown _countdown;
        [SerializeField]
        private CardMatcherMono matcherMono;
        
        [Header("Events")]
        [SerializeField]
        private UnityEvent OnWon;
        [SerializeField]
        private UnityEvent OnLost;
        
        
        private List<Card.MonoCard> _cards = new List<Card.MonoCard>();
        private LevelData _level;
        private ICardSetGenerator _generator;
 

        [Inject]
        private void Init(LevelData levelData , ICardSetGenerator cardSetGenerator)
        {
            _level = levelData;
            _generator = cardSetGenerator;
        }

        private void Start()
        {
            Init();
        }

        private void Init()
        {
            matcherMono.MatchCount = _cardsMatchCount;
            matcherMono.CardMatcher.OnMatched += OnMatched;

            var args = new CardSetGenerationArgs(_level.CardsCount, _cardsMatchCount);
            var cards = _generator.GenerateSet(args);

            foreach (var card in cards)
                InitCard(card);
  
            _countdown.Start(_level.TimeInSec);
            _countdown.OnReachedZero += () => OnLost.Invoke();
        }

        private void OnMatched(List<Card.MonoCard> monoCards)
        {
            monoCards.ForEach(c => _cards.Remove(c));
            if (_cards.Count > 0) 
                return;
            
            _countdown.Stop();
            OnWon?.Invoke();
        }

        private void InitCard(Card.MonoCard monoCard)
        {
            monoCard.transform.SetParent(_cardsContainer);
            monoCard.GetComponent<CardInteraction>().OnInteacted += () => matcherMono.TryShowCards(monoCard);
            _cards.Add(monoCard);
        }
    }
}
