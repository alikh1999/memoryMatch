using Gameplay.Card;
using UnityEngine;
using Zenject;

namespace Installer
{
    public class GameplayInstaller : MonoInstaller
    {
        public GameObject cardFactory;
        public GameObject cardsGenerator;
        [Header("Input")]

        [SerializeField]
        private bool _isWindowsBuild;

        public override void InstallBindings()
        {
            Container.Bind<ICardFactory>().To<CardFactory>().FromComponentOn(cardFactory).AsSingle();
            Container.Bind<ICardSetGenerator>().To<NumberCardsSetGenerator>().FromComponentOn(cardsGenerator).AsSingle();
        }
        
    }
}