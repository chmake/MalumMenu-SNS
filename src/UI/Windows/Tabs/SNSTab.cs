using UnityEngine;

namespace MalumMenu;

public class SNSTab : ITab
{
    public string name => "SNS";

    public void Draw()
    {
        GUILayout.BeginHorizontal();

        GUILayout.BeginVertical(GUILayout.Width(MenuUI.windowWidth * 0.425f));

        DrawRules();

        GUILayout.Space(15);

        DrawEnforcement();

        GUILayout.EndVertical();

        GUILayout.BeginVertical();

        DrawCurrentRules();

        GUILayout.EndVertical();

        GUILayout.EndHorizontal();
    }

    private void DrawRules()
    {
        GUILayout.Label("SNS Rules", GUIStylePreset.TabSubtitle);

        SNS.SNSRules.NoVenting = GUILayout.Toggle(
            SNS.SNSRules.NoVenting,
            " No Venting"
        );

        SNS.SNSRules.ShapeshiftBeforeKill = GUILayout.Toggle(
            SNS.SNSRules.ShapeshiftBeforeKill,
            " Shapeshift Before Kill"
        );

        SNS.SNSRules.NoReports = GUILayout.Toggle(
            SNS.SNSRules.NoReports,
            " No Reports"
        );

        SNS.SNSRules.NoMeetings = GUILayout.Toggle(
            SNS.SNSRules.NoMeetings,
            " No Meetings"
        );

        SNS.SNSRules.CommsOnlySabotage = GUILayout.Toggle(
            SNS.SNSRules.CommsOnlySabotage,
            " Communications Only"
        );
    }

    private void DrawEnforcement()
    {
        GUILayout.Label("Enforcement", GUIStylePreset.TabSubtitle);

        SNS.SNSRules.AutoKick = GUILayout.Toggle(
            SNS.SNSRules.AutoKick,
            " Automatic Kick"
        );

        SNS.SNSRules.AutoAnnounce = GUILayout.Toggle(
            SNS.SNSRules.AutoAnnounce,
            " Automatic Rules Announcement"
        );

        GUILayout.Space(8);

        if (GUILayout.Button("Reset SNS Rules"))
        {
            SNS.SNSRules.Reset();
        }
    }

    private void DrawCurrentRules()
    {
        GUILayout.Label("Current Rules", GUIStylePreset.TabSubtitle);

        GUILayout.TextArea(
            SNS.SNSRules.GetRulesText(),
            GUILayout.MinHeight(150)
        );
    }
}
