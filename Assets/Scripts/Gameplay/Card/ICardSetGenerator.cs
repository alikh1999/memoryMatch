using System.Collections.Generic;

namespace Gameplay.Card
{
    public interface ICardSetGenerator
    {
        List<CardContainer> GenerateSet(CardSetGenerationArgs args);
    }
}