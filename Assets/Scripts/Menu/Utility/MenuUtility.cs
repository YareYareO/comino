using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

public class MenuUtility
{
    public static string[] GetEnvironments()
    {
        // now not in use 
        UnityEngine.Object[] objectfiles =  Resources.LoadAll("JSON/", typeof(TextAsset));
        string[] files = MenuUtility.convertObjectsToStrings(objectfiles);

        return files;
    } 

    public static string[] GetStartingpositions()
    {
        return MenuUtility.convertStartsToStrings(SearchData.PointList.startingpositions);
    }

    public static string[] GetGoals()
    {
        return MenuUtility.convertTargetsToStrings(SearchData.PointList.targets);
    }

    public static string[] convertTargetsToStrings(List<Target> listOfTargets)
    {
        string[] listofnames = new string[listOfTargets.Count];
        for(int i=0; i < listofnames.Length; i++)
        {
            listofnames[i] = listOfTargets[i].Name;
        }
        
        return listofnames;
    }
    
    public static string[] convertStartsToStrings(List<StartingPosition> listOfSps)
    {
        string[] listofnames = new string[listOfSps.Count];
        for(int i=0; i < listofnames.Length; i++)
        {
            listofnames[i] = listOfSps[i].Name;
        }
        
        return listofnames;
    } 

    public static string[] convertObjectsToStrings(UnityEngine.Object[] listOfObjects)
    {
        string[] files = new string[listOfObjects.Length];
        
        for(int i = 0; i < listOfObjects.Length; i++)
        {
            files[i] = listOfObjects[i].name;
        }

        return files;
    }

    public static string[] convertArrayListToStringArray(List<string> list)
    {
        string[] array = new string[list.Count];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = list[i];
        }
        return array;
    }

    // public static VisualElement GetRoot()
    // {
    //     //VisualElement root = GetComponent<UIDocument>().rootVisualElement;
    //     //return root;
    // }
}
