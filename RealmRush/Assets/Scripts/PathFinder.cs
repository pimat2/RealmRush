using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{
    [SerializeField] Vector2Int startCoordinates;
    [SerializeField] Vector2Int endCoordinates;
    
    
    Node startNode;
    Node endNode;
    Node currentSearchNode;
    
    Queue<Node> frontier = new Queue<Node>();
    Dictionary<Vector2Int, Node> reached = new Dictionary<Vector2Int, Node>();
    
    Vector2Int[] directions = {Vector2Int.right, Vector2Int.left, Vector2Int.up, Vector2Int.down};
    GridManager gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        if(gridManager != null){
            grid = gridManager.Grid;
        }
        startNode = new Node(startCoordinates, true);
        endNode = new Node(endCoordinates, true);    
    }
    void Start()
    {
        BreathFirstSearch();
    }
    void ExploreNeighbors(){
        List<Node> neighbors = new List<Node>();
        foreach (Vector2Int direction in directions)
        {
            Vector2Int neighborCoords = currentSearchNode.coordinates + direction;
            if(grid.ContainsKey(neighborCoords)){
                neighbors.Add(grid[neighborCoords]);
            }
        }
        foreach (Node neighbor in neighbors)
        {
            if(!reached.ContainsKey(neighbor.coordinates) && neighbor.isWalkable){
                reached.Add(neighbor.coordinates, neighbor);
                frontier.Enqueue(neighbor);
            }
        }
    }
    void BreathFirstSearch(){
        bool isRunning = true;
        frontier.Enqueue(startNode);
        reached.Add(startCoordinates, startNode);
        while(frontier.Count > 0 && isRunning){
            currentSearchNode = frontier.Dequeue();
            currentSearchNode.isExplored = true;
            ExploreNeighbors();
            if(currentSearchNode.coordinates == endCoordinates){
                isRunning = false;
            }
        }
    }
}
