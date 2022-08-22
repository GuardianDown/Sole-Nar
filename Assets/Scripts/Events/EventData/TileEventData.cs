using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.Events
{
    public class TileEventData : ScriptableObject
    {
        [SerializeField]
        private string _id = null;

        [SerializeField]
        private bool _isPassable;

        [SerializeField]
        private int _wasteOfFuel;

        [SerializeField]
        private Sprite[] _tileSprites = null;

        [SerializeField]
        private string _titleText = null;

        [TextArea(5, 20)]
        [SerializeField]
        private string[] _introductionTexts = null;

        public string ID => _id;
        public bool IsPassable => _isPassable;
        public int WasteOfFuel => _wasteOfFuel;
        public IEnumerable<Sprite> TileSprites => _tileSprites;
        public string TitleText => _titleText;
        public IEnumerable<string> IntroductionTexts => _introductionTexts;
    }
}
