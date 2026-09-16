namespace MalumMenu.SNS;

public static class SNSRuleManager
{
    public static void RecordShapeshift(byte playerId, byte targetId)
    {
        SNSShapeshiftTracker.TrackInternal(playerId, targetId);
    }

    public static bool HasShapeshiftedInto(byte playerId, byte targetId)
    {
        return SNSShapeshiftTracker.IsShapeshiftedAs(playerId, targetId);
    }

    public static void ClearShapeshift(byte playerId)
    {
        SNSShapeshiftTracker.ClearInternal(playerId);
    }

    public static void ClearAll()
    {
        SNSShapeshiftTracker.ClearAllInternal();
    }

    public static void ResetPlayer(byte playerId)
    {
        ClearShapeshift(playerId);
    }
}
