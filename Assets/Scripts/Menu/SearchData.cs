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
            setWholeJson(chosenEnvironment);
        }
    }

    private async static void setWholeJson(string env)
    {
        WholeJson = await FirebaseManager.DB.RetrieveMap(env);
    }

    private static string wholeJson;
    public static string WholeJson
    {
        get { return wholeJson;}
        set 
        {
            wholeJson = value;
            PointList = JsonUtility.FromJson<PointList>(wholeJson);
        }
    }

    public static PointList PointList { get; set;}

    public static Target Target { get; set;}
    public static void setTargetFromString(string s)
    {
        foreach(Target t in PointList.targets)
        {
            if(t.Name == s)
            {
                Target = t;
                return;
            }
        }
    }

    public static StartingPosition Startposition { get; set;}
    public static void setStartPFromString(string s)
    {
        foreach(StartingPosition sp in PointList.startingpositions)
        {
            if(sp.Name == s)
            {
                //Debug.Log(sp.Name);
                Startposition = sp;
                return;
            }
        }
    }

    public static List<Point> Path { get; set;}

    //SPÄTER EINFÜGEN bei neuer chosenenvironment werden auch die anderen werte gelöscht (target startposition path)


}