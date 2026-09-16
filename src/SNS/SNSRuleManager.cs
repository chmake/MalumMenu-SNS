using System.Collections.Generic;

namespace MalumMenu.SNS;

public static class SNSRuleManager
{
    private static readonly Dictionary<byte, byte> LastShapeshiftTargets = new();

    public static void RecordShapeshift(byte playerId, byte targetId)
    {
        LastShapeshiftTargets[playerId] = targetId;
    }

    public static bool HasShapeshiftedInto(byte playerId, byte targetId)
    {
        return LastShapeshiftTargets.TryGetValue(playerId, out byte lastTarget)
               && lastTarget == targetId;
    }

    public static void ClearShapeshift(byte playerId)
    {
        LastShapeshiftTargets.Remove(playerId);
    }

    public static void ClearAll()
    {
        LastShapeshiftTargets.Clear();
    }

    public static void ResetPlayer(byte playerId)
    {
        ClearShapeshift(playerId);
    }
}
