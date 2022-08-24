using System;

namespace SoleNar.UI
{
    public interface IPanaceniteEventView : ITileEventView
    {
        event Action onInspect;
        event Action onClose;
    }
}
