using System;

namespace Gameplay.Card
{
    public class CardSetGenerationArgs
    {
        public int OriginalCount { get; }
        public int MatchCount { get; }

        public CardSetGenerationArgs(int originalCount, int matchCount)
        {
            if (originalCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(originalCount));
            
            if (matchCount <= 1)
                throw new ArgumentOutOfRangeException(nameof(matchCount));

            OriginalCount = originalCount;
            MatchCount = matchCount;
        }
    }
}