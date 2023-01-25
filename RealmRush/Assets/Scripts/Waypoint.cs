using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isNotPlaceable;
   void OnMouseDown() {
        if(isNotPlaceable){
            return;
        }
        else{
            Debug.Log(transform.name);
        }
   }
}
