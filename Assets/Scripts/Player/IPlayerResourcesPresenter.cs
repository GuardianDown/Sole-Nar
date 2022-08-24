namespace SoleNar.Player
{
    public interface IPlayerResourcesPresenter<T>
    {
        void UpdateView(string id, T value);
    }
}
