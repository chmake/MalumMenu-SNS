using System;
using System.Collections.Generic;

namespace MalumMenu.SNS;

public static class SNSShapeshiftTracker
{
    private static readonly Dictionary<byte, byte> ShapeshiftTargets = new();

    public static void Track(byte playerId, byte targetId)
    {
        ShapeshiftTargets[playerId] = targetId;
        SNSRuleManager.RecordShapeshift(playerId, targetId);
    }

    public static bool IsShapeshiftedAs(byte playerId, byte targetId)
    {
        return ShapeshiftTargets.TryGetValue(playerId, out byte currentTarget)
               && currentTarget == targetId;
    }

    public static void Clear(byte playerId)
    {
        ShapeshiftTargets.Remove(playerId);
        SNSRuleManager.ClearShapeshift(playerId);
    }

    public static void ClearAll()
    {
        ShapeshiftTargets.Clear();
        SNSRuleManager.ClearAll();
    }
}
