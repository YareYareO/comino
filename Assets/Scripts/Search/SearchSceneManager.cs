using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SearchSceneManager : MonoBehaviour
{

    private static List<GameObject> gameobjectList = new List<GameObject>();
    private static GameObject lastObject;
    public GameObject ARCamera;

    private void Start() {
        if(ARCamera == null)
        {
            ARCamera = GameObject.Find("AR Camera");
        }

        TargetHandler.StartingPosition startposition = SearchData.Startposition;
        List<TargetHandler.Point> path = SearchData.Path;

        foreach(TargetHandler.Point c in path)
        {
            GameObject GameObj = Instantiate(Resources.Load("RealPoint") as GameObject);
            GameObj.transform.position = new Vector3(c.PosX, c.PosY, c.PosZ);
            GameObj.transform.localEulerAngles = new Vector3(0, c.RotY, 0);
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
