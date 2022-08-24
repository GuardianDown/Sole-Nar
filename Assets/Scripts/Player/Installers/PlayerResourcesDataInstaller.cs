using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerResourcesDataInstaller : MonoInstaller
    {
        [SerializeField]
        private PlayerResourceDataInt[] _playerResourceData = null;

        public override void InstallBindings()
        {
            Container
                .Bind<IEnumerable<IPlayerResourceData<int>>>()
                .FromInstance(_playerResourceData)
                .AsSingle();

            List<IPlayerResource<int>> playerResources = new List<IPlayerResource<int>>(_playerResourceData.Length); 

            foreach(PlayerResourceDataInt data in _playerResourceData)
                playerResources.Add(new PlayerResource(data));

            Container.Bind<IEnumerable<IPlayerResource<int>>>().FromInstance(playerResources).AsSingle();
        }
    }
}
