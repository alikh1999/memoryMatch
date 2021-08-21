using System;
using UnityEngine;
namespace Gameplay.Card
{
    public class MonoCard : MonoBehaviour
    {
        private void Awake() 
        {
            _card = new Card();
        }
        
        private Card _card;

        public Card Card => _card;
    }
}