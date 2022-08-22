using System.Collections.Generic;
using UnityEngine;

namespace SoleNar.UI
{
    public interface ITileEventView
    {
        void Enable();

        void Disable();

        void SetTitle(string title);

        void SetEventText(string text);

        void SetEventSprites(IEnumerable<Sprite> sprites);

        void SetDiceValue(int value);

        void ResetDiceView();
    }
}