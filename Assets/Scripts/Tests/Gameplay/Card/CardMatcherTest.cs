using Gameplay.Card;
using NUnit.Framework;
using UnityEngine;

namespace Tests.UI
{
    public class CardMatcherTest
    {
        [Test]
        public void Should_ReturnFalse_CanTracFunction_When_Card_IsProcessedAlready()
        {
            //arrange
            var cardMatcher = new CardMatcher();
            cardMatcher.IsMatching = false;
            var cardMono = new GameObject("test").AddComponent<MonoCard>();
            cardMatcher.CanTrack(cardMono);

            //act
            var result = cardMatcher.CanTrack(cardMono);
            
            //assert
            Assert.AreEqual(false, result);
        }
        
        [Test]
        public void Should_ReturnFalse_CanTrackFunction_When_MatchingProcess_IsActive()
        {
            //arrange
            var cardMatcher = new CardMatcher();
            cardMatcher.IsMatching = true;
            var cardMono = new GameObject("test").AddComponent<MonoCard>();

            //act
            var result = cardMatcher.CanTrack(cardMono);
            
            //assert
            Assert.AreEqual(false, result);
        }
    }
}