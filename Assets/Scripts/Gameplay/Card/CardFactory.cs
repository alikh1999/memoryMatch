using UnityEngine;

namespace Gameplay.Core
{
    public class CardFactory : MonoBehaviour, ICardFactory
    {
        [SerializeField]
        private MonoCard _prefab;
        public MonoCard Create()
        {
            var card = Instantiate(_prefab);
            return card;
        }
    }
}