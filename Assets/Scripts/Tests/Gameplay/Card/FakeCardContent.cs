using Gameplay.Core;

namespace Tests.UI
{
         /// <summary>
        /// It does not equal to anything 
        /// </summary>
        public class FakeCardContent : CardContent
        {
            public override bool IsEqual(CardContent content)
            {
                return false;
            }
        }
}