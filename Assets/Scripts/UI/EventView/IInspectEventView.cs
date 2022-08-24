using System;

namespace SoleNar.UI
{
    public interface IInspectEventView : ITileEventView
    {
        event Action onInspect;
        event Action onIgnore;
        event Action onClose;
    }
}
