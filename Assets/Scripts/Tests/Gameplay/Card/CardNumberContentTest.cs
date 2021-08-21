using Gameplay.Card;
using NUnit.Framework;

namespace Tests.UI
{
    public class CardNumberContentTest
    {
        [Test]
        public void Should_ReturnFalse_When_IsEqual_Called_WithPerimeterThat_IsNotSame_BaseClass()
        {
            //arrange
            int randomNumber = 2;
            var cardNumberContent = new CardNumberContent(randomNumber);
            var cardSomethingContent = new CardSomethingContent();
            
            //act
            var result = cardNumberContent.IsEqual(cardSomethingContent);
            
            //assert
            Assert.AreEqual(false, result);
        }
        
        
        
        
        private class CardSomethingContent : CardContent
        {
            public override bool IsEqual(CardContent content)
            {
                return false;
            }
        }
    }
}