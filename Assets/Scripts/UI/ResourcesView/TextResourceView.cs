using UnityEngine;
using TMPro;

namespace SoleNar.UI
{
    public class TextResourceView : MonoBehaviour, IResourceView<int>
    {
        [SerializeField]
        private TextMeshProUGUI _text = null;

        [SerializeField]
        private string _resourceName = null;

        [SerializeField]
        private string _id = null;

        public string ID => _id;

        public void SetResource(int value) => 
            _text.text = $"{_resourceName}({value})";
    }
}
