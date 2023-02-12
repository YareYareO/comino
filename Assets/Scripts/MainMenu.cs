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
        if(SearchData.Target != null | SearchData.Startposition != null | SearchData.PointList != null)
        {
            SearchData.Path = HelperSearchAlgorithm.DominoAlgorithm(SearchData.PointList.connections, SearchData.Target, SearchData.Startposition);
            if(SearchData.Path == null)
            {
                Debug.Log("Target could not be found. It is not accessible.");
            }
            else
            {
                SceneManager.LoadScene("Search");
            }
        }
        else { Debug.Log("Werte sind Null");}
    }

}