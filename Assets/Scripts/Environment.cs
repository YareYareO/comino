using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment : MonoBehaviour
{

    //Check if environments folder exists
    private void Awake() {
        string ENVIRONMENTS = Application.dataPath + "/Environments/";
        if(!Directory.Exists(ENVIRONMENTS)){
            Directory.CreateDirectory(ENVIRONMENTS);
            print("folder created");
        }
    }
 
    //Reaction to Button click
    public void chooseSource()
    {
        Object[] objectfiles =  Resources.LoadAll("JSON/", typeof(TextAsset));
        string[] files = new string[objectfiles.Length];
        
        for(int i = 0; i < objectfiles.Length; i++)
        {
            files[i] = objectfiles[i].name;
            files[i] = files[i];
        }
        UIHelper.createScrollList(0, files);
    } 
}
