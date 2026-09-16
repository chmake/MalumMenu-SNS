using System;
using System.Collections.Generic;
using BepInEx.Logging;
using InnerNet;

namespace MalumMenu.SNS;

public static class SNSViolationHandler
{
    private static readonly HashSet<byte> HandledViolations = new();

    public static void Handle(byte playerId, string reason)
    {
        if (!SNSRules.AutoKick)
            return;

        if (HandledViolations.Contains(playerId))
            return;

        HandledViolations.Add(playerId);

        try
        {
            var client = AmongUsClient.Instance;

            if (client == null)
                return;

            client.KickPlayer(playerId, false);

            MalumMenu.Log?.LogWarning(
                $"[SNS] Kicked player {playerId}: {reason}"
            );
        }
        catch (Exception ex)
        {
            MalumMenu.Log?.LogError(
                $"[SNS] Failed to kick player {playerId}: {ex}"
            );
        }
    }

    public static void ClearPlayer(byte playerId)
    {
        HandledViolations.Remove(playerId);
    }

    public static void ClearAll()
    {
        HandledViolations.Clear();
    }
}
