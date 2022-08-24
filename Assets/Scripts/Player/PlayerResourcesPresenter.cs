using System.Linq;
using System.Collections.Generic;
using Zenject;

namespace SoleNar.Player
{
    internal sealed class PlayerResourcesPresenter : IPlayerResourcesPresenter<int>
    {
        private readonly List<IResourceView<int>> _resourceViews;
        private readonly IEnumerable<IPlayerResource<int>> _playerResources;

        [Inject]
        public PlayerResourcesPresenter(IEnumerable<IPlayerResource<int>> playerResources, List<IResourceView<int>> resourceViews)
        {
            _resourceViews = resourceViews;
            _playerResources = playerResources;

            foreach (IPlayerResource<int> playerResource in _playerResources)
            {
                playerResource.onResourceValueChanged += UpdateView;
                UpdateView(playerResource.ID, playerResource.CurrentValue);
            }
        }

        public void UpdateView(string id, int value) => 
            _resourceViews
            .SingleOrDefault(view => view.ID == id)
            .SetResource(value);
    }
}
