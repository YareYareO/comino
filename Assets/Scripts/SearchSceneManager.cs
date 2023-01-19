using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SearchSceneManager : MonoBehaviour
{

    private static List<TargetHandler.Connection> path = new List<TargetHandler.Connection>();
    private static List<GameObject> gameobjectList = new List<GameObject>();
    private static TargetHandler.StartingPosition startposition;
    private static GameObject lastObject;
    public static GameObject ARCamera;

    private void Start() {
        if(ARCamera == null)
        {
            ARCamera = GameObject.Find("AR Camera");
        }

        foreach(TargetHandler.Connection c in path)
        {
            GameObject GameObj = Instantiate(Resources.Load("RealPoint") as GameObject);
            GameObj.transform.position = new Vector3(c.PosX-startposition.PosX, c.PosY-startposition.PosY, c.PosZ-startposition.PosZ);
            GameObj.transform.localEulerAngles = new Vector3(0, c.RotY - 90 -startposition.RotY, 0);
            GameObj.name = c.Name;
            gameobjectList.Add(GameObj);
        }
        lastObject = GameObject.Find(gameobjectList[gameobjectList.Count - 1].name);
    }

    public static void removeLastItem()
    {   
        GameObject go = GameObject.Find(gameobjectList[gameobjectList.Count - 1].name);
        if(go)
        {
            Destroy(go.gameObject);
            Debug.Log(gameobjectList[gameobjectList.Count - 1].name + " has been destroyed!");
        }
        gameobjectList.RemoveAt(gameobjectList.Count - 1);  

        if(gameobjectList.Count == 0)
        {
            endSearch();
            //SceneManager.LoadScene("StartMenu");
        }
        else
        {
            lastObject = GameObject.Find(gameobjectList[gameobjectList.Count - 1].name);

        }
    }

    //getter
    public static GameObject getLO()
    {
        if(lastObject != null)
        {
            return lastObject;
        }
        else 
        {
            return null;
        }
        
    }
    //setter
    public static void setPath(List<TargetHandler.Connection> p, TargetHandler.StartingPosition s)
    {
        path = p;
        startposition = s;
    }

    private static void endSearch()
    {
        lastObject = null;
        //GameObject g = Instantiate(Resources.Load("Canvas") as GameObject);
        //g.SetActive(true);
        //g.transform.SetParent(ARCamera.transform);
        //Debug.Log("sheesh");
        SceneManager.LoadScene("StartMenu");
    }

}