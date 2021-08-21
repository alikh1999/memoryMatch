using Gameplay.Core;
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
        private MonoCardMatcher matcher;
        
        [Header("Events")]
        [SerializeField]
        private UnityEvent OnWon;
        [SerializeField]
        private UnityEvent OnLost;
        
        
        private List<Card> _cards = new List<Card>();
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
            matcher.MatchCount = _cardsMatchCount;
            matcher.Matched += OnMatched;

            var args = new CardSetGenerationArgs(_level.CardsCount, _cardsMatchCount);
            var cards = _generator.GenerateSet(args);

            foreach (var card in cards)
                InitCard(card);
  
            _countdown.Start(_level.TimeInSec);
            _countdown.OnReachedZero += () => OnLost.Invoke();
        }

        private void OnMatched(List<Card> cards)
        {
            cards.ForEach(c => _cards.Remove(c));
            if (_cards.Count > 0) 
                return;
            
            _countdown.Stop();
            OnWon?.Invoke();
        }

        private void InitCard(Core.MonoCard monoCard)
        {
            monoCard.transform.SetParent(_cardsContainer);
            monoCard.GetComponent<CardInteraction>().OnInteacted += () => matcher.TryShowCards(monoCard);
            _cards.Add(monoCard.Card);
        }
    }
}
