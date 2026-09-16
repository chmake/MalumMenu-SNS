namespace MalumMenu.SNS;

public static class SNSRules
{
    public static bool NoVenting { get; set; } = true;
    public static bool ShapeshiftBeforeKill { get; set; } = true;
    public static bool NoReports { get; set; } = true;
    public static bool NoMeetings { get; set; } = true;
    public static bool CommsOnlySabotage { get; set; } = true;
    public static bool AutoKick { get; set; } = true;
    public static bool AutoAnnounce { get; set; } = true;

    public static string GetRulesText()
    {
        return "SNS Rules: Imps can't vent, SS before killing your target, no reports or meetings, comms only. Break the rules = kick.";
    }

    public static bool AreAnyRulesEnabled()
    {
        return NoVenting ||
               ShapeshiftBeforeKill ||
               NoReports ||
               NoMeetings ||
               CommsOnlySabotage ||
               AutoKick ||
               AutoAnnounce;
    }

    public static void Reset()
    {
        NoVenting = true;
        ShapeshiftBeforeKill = true;
        NoReports = true;
        NoMeetings = true;
        CommsOnlySabotage = true;
        AutoKick = true;
        AutoAnnounce = true;
    }
}
