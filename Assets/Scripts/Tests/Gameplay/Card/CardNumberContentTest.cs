using Gameplay.Core;
using NUnit.Framework;

namespace Tests.UI
{
    //todo: test other way when isEqual must return true
    public partial class CardNumberContentTest
    {
        [Test]
        public void Should_ReturnFalse_When_IsEqual_Called_WithPerimeterThat_IsNotSame_BaseClass()
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
    }
}