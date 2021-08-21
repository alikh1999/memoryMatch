using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Objects/LevelData")]
    public class LevelData : ScriptableObject
    {
        public int TimeInSec => timeInSec;
        public int CardsCount => cardsCount;
        
        [SerializeField]
        private int timeInSec, cardsCount;
    }
}
