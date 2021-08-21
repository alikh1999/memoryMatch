namespace Gameplay.Core
{
    public class CardNumberContent : CardContent
    {
        public int Number { get; }
        public CardNumberContent(int number)
        {
            Number = number;
        }

        public override bool IsEqual(CardContent content)
        {
            if (content is CardNumberContent c)
            {
                return c.Number == Number;
            }

            return false;
        }
    }
}
