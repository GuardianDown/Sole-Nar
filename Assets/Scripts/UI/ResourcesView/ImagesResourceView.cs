using UnityEngine;
using UnityEngine.UI;

namespace SoleNar.UI
{
    public class ImagesResourceView : MonoBehaviour, IResourceView<int>
    {
        [SerializeField]
        private Image[] _images = null;

        [SerializeField]
        private string _id = null;

        public string ID => _id;

        public void SetResource(int value)
        {
            for(int i = 0; i < _images.Length; ++i)
                _images[i].gameObject.SetActive(i < value);
        }
    }
}
