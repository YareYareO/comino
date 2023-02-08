using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchData
{
    private static string chosenEnvironment;
    public static string ChosenEnvironment
    {
        get { return chosenEnvironment;}
        set 
        {
            chosenEnvironment = value;
            WholeJson = (Resources.Load<TextAsset>("JSON/" + chosenEnvironment).text);
        }
    }

    private static string wholeJson;
    public static string WholeJson
    {
        get { return wholeJson;}
        set 
        {
            wholeJson = value;
            PointList = JsonUtility.FromJson<TargetHandler.PointList>(wholeJson);
        }
    }

    public static TargetHandler.PointList PointList { get; set;}

    public static TargetHandler.Target Target { get; set;}
    public static void setTargetFromString(string s)
    {
        foreach(TargetHandler.Target t in PointList.targets)
        {
            if(t.Name == s)
            {
                Target = t;
                return;
            }
        }
    }

    public static TargetHandler.StartingPosition Startposition { get; set;}
    public static void setStartPFromString(string s)
    {
        foreach(TargetHandler.StartingPosition sp in PointList.startingpositions)
        {
            if(sp.Name == s)
            {
                Startposition = sp;
                return;
            }
        }
    }

    public static List<TargetHandler.Connection> Path { get; set;}

    //SPÄTER EINFÜGEN bei neuer chosenenvironment werden auch die anderen werte gelöscht (target startposition path)


}