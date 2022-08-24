namespace SoleNar.Player
{
    public interface IPlayerResourceData<T>
    {
        string ID { get; }
        T StartValue { get; }
        T MaxValue { get; }
    }
}
