using UnityEngine;

namespace Gameplay.Card
{
    public class CardFactory : MonoBehaviour, ICardFactory
    {
        [SerializeField]
        private CardContainer _prefab;
        public CardContainer Create()
        {
            var card = Instantiate(_prefab);
            return card;
        }
    }
}