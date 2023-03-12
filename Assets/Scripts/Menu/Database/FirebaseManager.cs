using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Firebase;
using Firebase.Database;
using static Firebase.Extensions.TaskExtension;
using System.Threading.Tasks;

public class FirebaseManager : MonoBehaviour
{
    private DatabaseReference dbreference;

    public static FirebaseManager DB;

    void Start()
    {
        dbreference = FirebaseDatabase.DefaultInstance.RootReference;
        DB = this;
    }

    public void SaveMap()
    {
        //TargetHandler.PointList map = SearchData.PointList;
        //string mapjson = JsonUtility.ToJson(map);
        //dbreference.Child("mapnames").Child(SearchData.ChosenEnvironment).SetValueAsync(SearchData.ChosenEnvironment);
        //dbreference.Child("maps").Child(SearchData.ChosenEnvironment).SetRawJsonValueAsync(mapjson);
    }

    public async Task<string> RetrieveMap(string nameOfMap)
    {
        string mapjson = "";

        await dbreference.Child("maps").Child(nameOfMap)
        .GetValueAsync().ContinueWithOnMainThread(task => 
        {
            if (task.IsFaulted)
            {
                Debug.Log("oops");
            }
            else if (task.IsCompleted) 
            {
                mapjson = task.Result.GetRawJsonValue();
            }
        });  

        return mapjson;
    }

    public async Task<string[]> RetrieveMapNames()
    {
        string[] mapnames = new string[0];

        await dbreference.Child("mapnames").GetValueAsync().ContinueWithOnMainThread(task => 
        {
            if (task.IsFaulted) {
            Debug.Log("oops");
            }

            else if (task.IsCompleted) 
            {
                List<string> nameslist = new List<string>();
                IEnumerable<DataSnapshot> childrenlist = task.Result.Children;

                foreach (DataSnapshot name in childrenlist)
                {
                    nameslist.Add(name.Value.ToString());
                }

                mapnames = MenuUtility.convertArrayListToStringArray(nameslist);  
            }  
        });
        return mapnames;
    }

}
