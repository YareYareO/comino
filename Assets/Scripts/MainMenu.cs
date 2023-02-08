using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System;
using System.Globalization;

public class MainMenu : MonoBehaviour
{
    public void StartSearch()
    {
        if(SearchData.Target != null & SearchData.Startposition != null & SearchData.PointList != null)
        {
            //TargetHandler.PointList data = getDataFromJson(wholeJson);
            SearchData.Path = HelperSearchAlgorithm.DominoAlgorithm(SearchData.PointList.connections, SearchData.Target, SearchData.Startposition);
            //quickestPath.Reverse();
            //SendPoints(quickestPath); 
            SceneManager.LoadScene("Search");
        }
        else { Debug.Log("Werte sind Null");}
    }

}