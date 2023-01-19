using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Startposition : MonoBehaviour
{
    public void setStartingPosition()
    {
        List<TargetHandler.StartingPosition> positions = Goal.getPositions();
        string[] ret = new string[positions.Count];
        for(int i=0; i < ret.Length; i++)
        {
            ret[i] = positions[i].Name;
        }

        UIHelper.createScrollList(2, ret);
    }
}
