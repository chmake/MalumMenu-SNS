using System;
using UnityEngine;

namespace MalumMenu.SNS;

public static class SNSAnnouncements
{
    private static bool announced;

    public static void Announce()
    {
        if (!SNSRules.AutoAnnounce || announced)
            return;

        announced = true;

        string rules = SNSRules.GetRulesText();

        try
        {
            if (HudManager.Instance == null)
                return;

            HudManager.Instance.Chat.AddChat(
                PlayerControl.LocalPlayer,
                rules
            );
        }
        catch (Exception ex)
        {
            MalumMenu.Log?.LogError(
                $"[SNS] Failed to announce rules: {ex}"
            );
        }
    }

    public static void Reset()
    {
        announced = false;
    }
}
