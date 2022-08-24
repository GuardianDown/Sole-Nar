namespace SoleNar.Events
{
    public interface IDiceRoll
    {
        int MaxValue { get; }
        int GetResult();
    }
}
