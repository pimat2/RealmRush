using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    [SerializeField] GameObject ballista;
    [SerializeField] bool isNotPlaceable;
    public bool IsNotPlaceable{ get { return isNotPlaceable; } }
    GameObject parentGameObject;
    void Start() {
        parentGameObject = GameObject.FindWithTag("Ballistas");    
    }
    void OnMouseDown() {
        if(isNotPlaceable){
            return;
        }
        else{
            GameObject tower = Instantiate(ballista,transform.position,Quaternion.identity);
            isNotPlaceable = true;
            tower.transform.parent = parentGameObject.transform;
            Debug.Log(transform.name);
        }
   }
   
}
