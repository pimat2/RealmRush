using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    
    [SerializeField] Tower ballista;
    [SerializeField] bool isNotPlaceable;
    public bool IsNotPlaceable{ get { return isNotPlaceable; } }
    GridManager gridManager;
    PathFinder pathFinder;
    Vector2Int coordinates = new Vector2Int();
    void Awake() {
        pathFinder = FindObjectOfType<PathFinder>();
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
        if(gridManager.GetNode(coordinates).isWalkable && !pathFinder.WillBlockPath(coordinates)){
             bool isPlaced = ballista.CreateTower(ballista, transform.position);
             isNotPlaceable = isPlaced;
             gridManager.BlockNode(coordinates);
        }
        // if(isNotPlaceable){
        //     return;
        // }
        // else{
        //     bool isPlaced =  ballista.CreateTower(ballista, transform.position);
        //     isNotPlaceable = isPlaced;
        // }
   }
   
}
