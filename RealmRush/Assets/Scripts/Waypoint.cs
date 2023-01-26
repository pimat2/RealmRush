using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    
    [SerializeField] Tower ballista;
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
            bool isPlaced =  ballista.CreateTower(ballista, transform.position);
            isNotPlaceable = isPlaced;
        }
   }
   
}
