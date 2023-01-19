using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public GameObject ARCamera;
    public GameObject TargetObject;
    internal float distanceToTargetObject;
    public float visionRange = 10;
    private float reachedRange = 1;
    public MeshRenderer mesh;

    private void Awake(){

        mesh.enabled = false;
        if(ARCamera == null)
        {
            ARCamera = GameObject.Find("AR Camera");
        }
    } 

    private void FixedUpdate() {
        if(ARCamera != null)
        {
            distanceToTargetObject = Vector3.Distance(transform.position, ARCamera.transform.position);

            if(distanceToTargetObject < visionRange)
            {
                mesh.enabled = true;
            } else {
                mesh.enabled = false;
            }
        }
    }

    private void Update()
    {
        if(distanceToTargetObject < reachedRange)
        {
            SearchSceneManager.removeLastItem();
        }
    }


    #if UNITY_EDITOR
        private void OnDrawGizmos() {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.up, visionRange);
            UnityEditor.Handles.Label(transform.position, gameObject.name + "\nRange = " + visionRange);

        }
    #endif
}