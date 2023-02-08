
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    //Reaction to Buttonclick
    public void chooseTarget()
    {
        //myTargets = readFile();
        UIHelper.createScrollList(1, createList(SearchData.PointList.targets));
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

}
