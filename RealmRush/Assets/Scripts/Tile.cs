using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    [SerializeField] Tower ballista;
    [SerializeField] bool isNotPlaceable;
    public bool IsNotPlaceable{ get { return isNotPlaceable; } }
    GridManager gridManager;
    Vector2Int coordinates = new Vector2Int();
    void Awake() {
        gridManager = FindObjectOfType<GridManager>();
    }
    void Start() {
        if(gridManager != null){
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
            if(isNotPlaceable){
                gridManager.BlockNode(coordinates);
            }
        }    
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
