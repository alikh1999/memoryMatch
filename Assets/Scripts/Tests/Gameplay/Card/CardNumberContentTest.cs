using Gameplay.Core;
using NUnit.Framework;

namespace Tests.UI
{
    public class CardNumberContentTest
    {
        [Test]
        public void Should_ReturnFalse_When_IsEqual_Called_WithPerimeterThatIsNotSameBaseClass()
        {
            //arrange
            int randomNumber = 2;
            var cardNumberContent = new CardNumberContent(randomNumber);
            var fakeCardContent = new FakeCardContent();
            
            //act
            var result = cardNumberContent.IsEqual(fakeCardContent);
            
            //assert
            Assert.AreEqual(false, result);
        }

        [Test]
        public void Should_ReturnTrue_When_IsEqual_Called_WithPerimeterThatSameAsBaseClass()
        {
            //arrange
            int randomNumber = 2;
            var cardNumberContent = new CardNumberContent(randomNumber);
            var cardNumberContent1 = new CardNumberContent(randomNumber);
            
            //act
            var result = cardNumberContent.IsEqual(cardNumberContent1);
            
            //assert
            Assert.AreEqual(true, result);
        }
    }
}