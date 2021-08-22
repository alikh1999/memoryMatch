using UnityEngine;
using NUnit.Framework;
using Gameplay.Core;

namespace Tests.UI
{
    public class CardTest
    {
        
        [Test]
        public void Should_Fire_ShowEvent_When_Show_Called()
        {
            //arrange
            var card = CreateCard();
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
        public void Should_Fire_ShowEvent_OnlyOneTime_When_Show_HasBeenCalledTwiceWithoutCallingHide()
        {
            //arrange
            bool isCalledOneTime = false;
            var card = CreateCard();
            card.Shown += () =>
            {
                isCalledOneTime = !isCalledOneTime;
            };
                
            //act
            card.Show();
            card.Show();
            
            //assert
            Assert.AreEqual(true, isCalledOneTime);
        }

        [Test]
        public void Should_Fire_HiddenEvent_When_Hide_Called()
        {
            //arrange
            bool isHidden = false;
            var card = CreateCard();
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
        public void Should_Fire_HiddenEvent_OnlyOneTime_When_Hide_HasBeenCalled_TwiceWithoutCallingShow()
        {
            //arrange
            bool isCalledOneTime = false;
            var card = CreateCard();
            card.Hidden += ()=>
            {
                isCalledOneTime = !isCalledOneTime;
            };
            card.Show();
            
            //act
            card.Hide();
            card.Hide();
            
            //assert
            Assert.AreEqual(true, isCalledOneTime);
        }

        [Test]
        public void Should_Fire_DiscardedEvent_When_Discard_Called()
        {
            //arrange
            bool isDiscarded = false;
            var card = CreateCard();
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
            var card = CreateCard();
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
        

        private Card CreateCard()
        {
            return new Card(new FakeCardContent());
        }
    }
}