using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    private static int whichValueToChange = 0;

    public static void createScrollList(int whichOne, string[] values)
    {
        
        GameObject newPanel = GameObject.Find("Panel");

        if(newPanel.transform.childCount > 0)
        {
            return;
        }
        foreach(string s in values)
        {
            GameObject listItem = Instantiate(Resources.Load("ListItem") as GameObject);
            listItem.name = s;
            listItem.transform.GetComponentInChildren<TextMeshProUGUI>().text = s;
            listItem.transform.SetParent(newPanel.transform);
        } 

        whichValueToChange = whichOne;
    }


    public static void changeValue(string value)
    {
        if(whichValueToChange == 0)
        {
            Goal.setChosenEnvironment(value);
        }
        else if(whichValueToChange == 1)
        {
            Goal.setGoal(value);
        }
        else if(whichValueToChange == 2)
        {
            Goal.setPosition(value);
        }

        GameObject newPanel = GameObject.Find("Panel");
        foreach(Transform child in newPanel.transform)
        {
            Destroy(child.gameObject);
        }

        GameObject scroller = GameObject.Find("Scroller");
        scroller.SetActive(false);
    }
}
