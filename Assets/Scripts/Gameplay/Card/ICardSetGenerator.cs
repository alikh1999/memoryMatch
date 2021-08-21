using System.Collections.Generic;

namespace Gameplay.Card
{
    public interface ICardSetGenerator
    {
        List<MonoCard> GenerateSet(CardSetGenerationArgs args);
    }
}