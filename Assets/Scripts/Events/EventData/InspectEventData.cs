using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Events
{
    [CreateAssetMenu(fileName = "InspectEventData", menuName = "GameData/Events/InspectData")]
    public class InspectEventData : TileEventData
    {
        [TextArea(5, 20)]
        [SerializeField]
        private string[] _ignoreTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _goodResultTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _averageResultTexts = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _badResultTexts = null;

        [SerializeField]
        private int _upperBoundOfBadResult = 2;

        [SerializeField]
        private int _upperBoundOfAverageResult = 4;

        [SerializeField]
        private string _badResultResourceID = null;

        [SerializeField]
        private string _averageResultResourceID = null;

        [SerializeField]
        private string _goodResultResourceID = null;

        [SerializeField]
        private int _badResultResourceCount;

        [SerializeField]
        private int _averageResultResourceCount;

        [SerializeField]
        private int _goodResultResourceCount;

        public IEnumerable<string> IgnoreTexts => _ignoreTexts;
        public IEnumerable<string> GoodResultTexts => _goodResultTexts;
        public IEnumerable<string> AverageResultTexts => _averageResultTexts;
        public IEnumerable<string> BadResultTexts => _badResultTexts;
        public int UpperBoundOfBadResult => _upperBoundOfBadResult;
        public int UpperBoundOfAverageResult => _upperBoundOfAverageResult;
        public string BadResultResourceID => _badResultResourceID;
        public string AverageResultResourceID => _averageResultResourceID;
        public string GoodResultResourceID => _goodResultResourceID;
        public int BadResultResourceCount => _badResultResourceCount;
        public int AverageResultResourceCount => _averageResultResourceCount;
        public int GoodResultResourceCount => _goodResultResourceCount;
    }
}