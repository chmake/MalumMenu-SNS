using HarmonyLib;
using MalumMenu.SNS;

namespace MalumMenu;

[HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.CoStartGame))]
public static class SNS_AmongUsClient_CoStartGame
{
    public static void Postfix()
    {
        SNSShapeshiftTracker.ClearAll();
        SNSViolationHandler.ClearAll();
        SNSAnnouncements.Reset();

        SNSAnnouncements.Announce();
    }
}

[HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameEnd))]
public static class SNS_AmongUsClient_OnGameEnd
{
    public static void Postfix(EndGameResult endGameResult)
    {
        SNSShapeshiftTracker.ClearAll();
        SNSViolationHandler.ClearAll();
        SNSAnnouncements.Reset();
    }
}

[HarmonyPatch(typeof(AmongUsClient), nameof(AmongUsClient.OnGameJoined))]
public static class SNS_AmongUsClient_OnGameJoined
{
    public static void Postfix(string gameIdString)
    {
        SNSShapeshiftTracker.ClearAll();
        SNSViolationHandler.ClearAll();
        SNSAnnouncements.Reset();
    }
}

[HarmonyPatch(typeof(PlayerPhysics), nameof(PlayerPhysics.RpcEnterVent))]
public static class SNS_PlayerPhysics_RpcEnterVent
{
    public static bool Prefix(PlayerPhysics __instance, int ventId)
    {
        if (!SNSRules.NoVenting)
            return true;

        PlayerControl player = __instance.myPlayer;

        if (player == null)
            return true;

        if (!player.Data.Role.IsImpostor)
            return true;

        SNSViolationHandler.Handle(
            player.PlayerId,
            "Impostor attempted to vent"
        );

        return false;
    }
}

[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.CheckShapeshift))]
public static class SNS_PlayerControl_CheckShapeshift
{
    public static void Postfix(
        PlayerControl __instance,
        PlayerControl target,
        bool shouldAnimate
    )
    {
        if (!SNSRules.ShapeshiftBeforeKill)
            return;

        if (__instance == null || target == null)
            return;

        if (!__instance.Data.Role.IsImpostor)
            return;

        SNSShapeshiftTracker.Track(
            __instance.PlayerId,
            target.PlayerId
        );
    }
}

[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.MurderPlayer))]
public static class SNS_PlayerControl_MurderPlayer
{
    public static bool Prefix(
        PlayerControl __instance,
        PlayerControl target,
        MurderResultFlags resultFlags
    )
    {
        if (!SNSRules.ShapeshiftBeforeKill)
            return true;

        if (__instance == null || target == null)
            return true;

        if (!__instance.Data.Role.IsImpostor)
            return true;

        if (SNSShapeshiftTracker.IsShapeshiftedAs(
                __instance.PlayerId,
                target.PlayerId))
        {
            return true;
        }

        SNSViolationHandler.Handle(
            __instance.PlayerId,
            "Impostor killed without shapeshifting into the target"
        );

        return false;
    }
}

[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.ReportDeadBody))]
public static class SNS_PlayerControl_ReportDeadBody
{
    public static bool Prefix(PlayerControl __instance)
    {
        if (!SNSRules.NoReports)
            return true;

        if (__instance == null)
            return true;

        SNSViolationHandler.Handle(
            __instance.PlayerId,
            "Reporting is disabled in SNS"
        );

        return false;
    }
}

[HarmonyPatch(typeof(PlayerControl), nameof(PlayerControl.StartMeeting))]
public static class SNS_PlayerControl_StartMeeting
{
    public static bool Prefix(PlayerControl __instance)
    {
        if (!SNSRules.NoMeetings)
            return true;

        if (__instance == null)
            return true;

        SNSViolationHandler.Handle(
            __instance.PlayerId,
            "Meetings are disabled in SNS"
        );

        return false;
    }
}
