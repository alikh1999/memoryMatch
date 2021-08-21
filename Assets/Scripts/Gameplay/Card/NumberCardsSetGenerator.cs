using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gameplay.Card
{
    public class NumberCardsSetGenerator :  BaseCardsSetGenerator, ICardSetGenerator
    {
        protected override List<CardNumberContent> GenerateContents(int count)
        {
            var numbers = Enumerable.Range(1, count);
            return numbers.Select(num => new CardNumberContent(num)).ToList();
        }
    }
}
