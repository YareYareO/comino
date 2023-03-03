using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Pointer : MonoBehaviour
{
    Vector3 targetPosition;

    private void Update() {
        if(SearchSceneManager.getLO() != null)
        {
            targetPosition = SearchSceneManager.getLO().transform.position;
            gameObject.transform.LookAt(targetPosition);
        }
    }
}