using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField][Range(0f, 5f)] float enemySpeed = 2f;
    List<Node> path = new List<Node>();
    Enemy enemy;
    GridManager gridManager;
    PathFinder pathFinder;
    void Awake() {
        gridManager = FindObjectOfType<GridManager>();
        pathFinder = FindObjectOfType<PathFinder>();
        enemy = GetComponent<Enemy>();    
    }
    void OnEnable()
    {
        RecalculatePath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    void RecalculatePath(){
        path.Clear();
        path = pathFinder.GetNewPath();
    }
    void ReturnToStart(){
        transform.position = gridManager.GetPositionFromCoordinates(pathFinder.StartCoordinates);
    }
    void FinishPath(){
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath(){
        for(int i = 0; i < path.Count; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 waypointPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;
            transform.LookAt(waypointPosition);
            while(travelPercent < 1f){
                transform.position = Vector3.Lerp(startPosition,waypointPosition,travelPercent);
                travelPercent += Time.deltaTime * enemySpeed;
                yield return new WaitForEndOfFrame();
            }
        }
        FinishPath();
    }
    
}
