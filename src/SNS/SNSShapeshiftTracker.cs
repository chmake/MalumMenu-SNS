using System.Collections.Generic;

namespace MalumMenu.SNS;

public static class SNSShapeshiftTracker
{
    private static readonly Dictionary<byte, byte> ShapeshiftTargets = new();

    public static void Track(byte playerId, byte targetId)
    {
        TrackInternal(playerId, targetId);
    }

    public static bool IsShapeshiftedAs(byte playerId, byte targetId)
    {
        return ShapeshiftTargets.TryGetValue(
            playerId,
            out byte currentTarget
        ) && currentTarget == targetId;
    }

    public static void Clear(byte playerId)
    {
        ClearInternal(playerId);
    }

    public static void ClearAll()
    {
        ClearAllInternal();
    }

    internal static void TrackInternal(byte playerId, byte targetId)
    {
        ShapeshiftTargets[playerId] = targetId;
    }

    internal static void ClearInternal(byte playerId)
    {
        ShapeshiftTargets.Remove(playerId);
    }

    internal static void ClearAllInternal()
    {
        ShapeshiftTargets.Clear();
    }
}
