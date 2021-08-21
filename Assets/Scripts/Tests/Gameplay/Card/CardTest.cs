using UnityEngine;
using NUnit.Framework;
using Gameplay.Card;

namespace Tests.UI
{
    //TODO: Write at least 6 more test
    public class CardTest
    {
        [Test]
        public void Should_Fire_ContentEventSet_When_Content_Is_Set()
        {
            //arrange
            var card = new Card();
            bool isSet = false;
            card.ContentSet += (Content) =>
            {isSet = true;};

            //act
            card.Content = null;

            //assert
            Assert.AreEqual(true, isSet);
        }

        [Test]
        public void Should_Fire_ShowEvent_When_Show_Called()
        {
            //arrange
            var card = new Card();
            bool isShowed = false;
            card.Shown += ()=>
            {
                isShowed = true;
            };

            //act
            card.Show();

            //assert
            Assert.AreEqual(true, isShowed);
        }

        [Test]
        public void Should_Fire_HiddenEvent_When_HideCard_Called()
        {
            //arrange
            bool isHidden = false;
            var card = new Card();
            card.Show();
            card.Hidden += () =>
            {
                isHidden = true;
            };
            
            //act
            card.Hide();
            
            //assert
            Assert.AreEqual(true, isHidden);
        }

        [Test]
        public void Should_Fire_DiscardedEvent_When_Discard_Called()
        {
            //arrange
            bool isDiscarded = false;
            var card = new Card();
            card.Discarded += () =>
            {
                isDiscarded = true;
            };
            
            //act
            card.Discard();
            
            //assert
            Assert.AreEqual(true, isDiscarded);
        }

        [Test]
        public void Should_Fire_DiscardedEvent_Only_OneTime_Whatever_Discard_Called_Multiple_Time()
        {
            //arrange
            bool isCalledOneTime = false;
            var card = new Card();
            card.Discarded += () =>
            {
                isCalledOneTime = !isCalledOneTime;
            };
            card.Discard();
            
            //act
            card.Discard();
            
            //assert
            Assert.AreEqual(true, isCalledOneTime);
        }
    }
}