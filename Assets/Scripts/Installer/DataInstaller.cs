using ScriptableObjects;
using UnityEngine;
using Zenject;

namespace Installer
{
    [CreateAssetMenu(fileName = "DataInstaller", menuName = "Installers/DataInstaller")]
    public class DataInstaller : ScriptableObjectInstaller<DataInstaller>
    {
        public LevelData levelData;
        public override void InstallBindings()
        {
            Container.BindInstance(levelData);
            SignalBusInstaller.Install(Container);
        }
    }
}