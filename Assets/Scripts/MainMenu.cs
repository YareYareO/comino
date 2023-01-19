using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Globalization;

public class MainMenu : MonoBehaviour
{

    private static TargetHandler.Target chosenTarget;
    private static TargetHandler.StartingPosition chosenPosition;
    private static string wholeJson;

    
    public void StartSearch()
    {
        if(chosenTarget != null & wholeJson != null)
        {
            TargetHandler.PointList data = getDataFromJson(wholeJson);
            List<TargetHandler.Connection> quickestPath = HelperSearchAlgorithm.DominoAlgorithm(data.connections, chosenTarget, chosenPosition);
            quickestPath.Reverse();
            SendPoints(quickestPath); 
            SceneManager.LoadScene("Search");
        }
    }

    private TargetHandler.PointList getDataFromJson(string json)
    {
        TargetHandler.PointList ret = JsonUtility.FromJson<TargetHandler.PointList>(json);
        return ret;
    }

    private void SendPoints(List<TargetHandler.Connection> path)
    {

        SearchSceneManager.setPath(path, chosenPosition);
    } 

    //setter
    public static void setValues(TargetHandler.Target t, string json, TargetHandler.StartingPosition p)
    {

        chosenTarget = t;
        wholeJson = json;
        chosenPosition = p;
    }

}