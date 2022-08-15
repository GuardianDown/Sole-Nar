using UnityEngine;


namespace SoleNar.Player
{
    public interface IPlayerData
    {
        Vector3Int StartPosition { get; }
        int StartHealthValue { get; }
        int MaxHealthValue { get; }
        int StartFortitudeValue { get; }
        int MaxFortitudeValue { get; }
        int StartAttackStreingthValue { get; }
        int MaxAttackStreingthValue { get; }
        int StartStealthValue { get; }
        int MaxStealthValue { get; }
        int StartFuelValue { get; }
        int MaxFuelValue { get; }
        int StartAmoniteValue { get; }
        int MaxAmoniteValue { get; }
        int StartRepairKitValue { get; }
        int StartTorpedoValue { get; }
        int StartTimeToRestValue { get; }
    }
}
