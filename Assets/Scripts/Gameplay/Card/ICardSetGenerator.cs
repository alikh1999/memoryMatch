using System.Collections.Generic;

namespace Gameplay.Core
{
    public interface ICardSetGenerator
    {
        List<MonoCard> GenerateSet(CardSetGenerationArgs args);
    }
}