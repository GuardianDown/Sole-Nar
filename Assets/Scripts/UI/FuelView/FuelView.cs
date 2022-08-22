using UnityEngine;
using UnityEngine.UI;

namespace SoleNar.UI
{
    public class FuelView : MonoBehaviour
    {
        [SerializeField]
        private Image[] _fuelImages = null;

        public void SetFuelImagesCount(int value)
        {
            for(int i = 0; i < _fuelImages.Length; ++i)
                _fuelImages[i].gameObject.SetActive(i < value);
        }
    }
}
