
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private static string chosenEnvironment;

    private static string wholeJson;

    private static List<TargetHandler.Target> myTargets;

    private static TargetHandler.Target chosenTarget;

    private static List<TargetHandler.StartingPosition> positions;

    private static TargetHandler.StartingPosition chosenPosition;

    //Reaction to Buttonclick
    public void chooseTarget()
    {
        myTargets = readFile();
        UIHelper.createScrollList(1, createList(myTargets));
    }

    private List<TargetHandler.Target> readFile()
    {
        var jsonText = Resources.Load<TextAsset>("JSON/" + chosenEnvironment).text;
        
        wholeJson = jsonText;

        TargetHandler.PointList pointlist = new TargetHandler.PointList();
        pointlist = JsonUtility.FromJson<TargetHandler.PointList>(jsonText);

        positions = pointlist.startingpositions;
        
        List<TargetHandler.Target> targets = pointlist.targets;

        return targets;
    }

    private string[] createList(List<TargetHandler.Target> t)
    {
        string[] ret = new string[t.Count];
        for(int i=0; i < ret.Length; i++)
        {
            ret[i] = t[i].Name;
        }
        
        return ret;
    }

    public static void setGoal(string s)
    {
        foreach(TargetHandler.Target t in myTargets)
        {
            if(t.Name == s)
            {
                chosenTarget = t;
                return;
            }
        }
    }

    //setter
    public static void setChosenEnvironment(string s)
    {
        chosenEnvironment = s;
    }

    public static List<TargetHandler.StartingPosition> getPositions()
    {
        return positions;
    }

    public static void setPosition(string value)
    {
        foreach(TargetHandler.StartingPosition p in positions)
        {
            if(p.Name == value)
            {
                chosenPosition = p;
                break;
            }
        }
        MainMenu.setValues(chosenTarget, wholeJson, chosenPosition);
    }
}
