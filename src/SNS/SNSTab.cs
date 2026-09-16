using UnityEngine;

namespace MalumMenu.SNS;

public static class SNSTab
{
    public static void Draw()
    {
        GUILayout.BeginVertical();

        GUILayout.Label("SNS Rules", GUI.skin.box);

        SNSRules.NoVenting = GUILayout.Toggle(
            SNSRules.NoVenting,
            "No Venting"
        );

        SNSRules.ShapeshiftBeforeKill = GUILayout.Toggle(
            SNSRules.ShapeshiftBeforeKill,
            "Shapeshift Before Kill"
        );

        SNSRules.NoReports = GUILayout.Toggle(
            SNSRules.NoReports,
            "No Reports"
        );

        SNSRules.NoMeetings = GUILayout.Toggle(
            SNSRules.NoMeetings,
            "No Meetings"
        );

        SNSRules.CommsOnlySabotage = GUILayout.Toggle(
            SNSRules.CommsOnlySabotage,
            "Communications Only Sabotage"
        );

        GUILayout.Space(8);

        GUILayout.Label("Enforcement", GUI.skin.box);

        SNSRules.AutoKick = GUILayout.Toggle(
            SNSRules.AutoKick,
            "Automatic Kick"
        );

        SNSRules.AutoAnnounce = GUILayout.Toggle(
            SNSRules.AutoAnnounce,
            "Automatic Rules Announcement"
        );

        GUILayout.Space(8);

        if (GUILayout.Button("Reset SNS Rules"))
        {
            SNSRules.Reset();
        }

        GUILayout.Space(8);

        GUILayout.Label("Current Rules", GUI.skin.box);

        GUILayout.TextArea(
            SNSRules.GetRulesText(),
            GUILayout.MinHeight(150)
        );

        GUILayout.EndVertical();
    }
}
