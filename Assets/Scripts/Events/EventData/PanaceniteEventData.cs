using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Events
{
    [CreateAssetMenu(fileName = "DepositeEventData", menuName = "GameData/Events/DepositeData")]
    public class PanaceniteEventData : TileEventData
    {
        [TextArea(5, 20)]
        [SerializeField]
        private string[] _collectTexts = null;

        [SerializeField]
        private string _resourceID = null;

        public IEnumerable<string> CollectTexts => _collectTexts;
        public string ResourceID => _resourceID;
    }
}
