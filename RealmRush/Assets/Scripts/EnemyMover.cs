using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Enemy))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField][Range(0f, 5f)] float enemySpeed = 2f;
    [SerializeField] List<Tile> path = new List<Tile>();
    Enemy enemy;
    void Start() {
        enemy = GetComponent<Enemy>();    
    }
    void OnEnable()
    {
        FindPath();
        ReturnToStart();
        StartCoroutine(FollowPath());
    }
    void FindPath(){
        path.Clear();
        GameObject parent = GameObject.FindGameObjectWithTag("Path");
        foreach (Transform child in parent.transform)
        {
            Tile waypoint = child.GetComponent<Tile>();
            if(waypoint != null){
                path.Add(waypoint);
            }
        }   
    }
    void ReturnToStart(){
        transform.position = path[0].transform.position;
    }
    void FinishPath(){
        enemy.StealGold();
        gameObject.SetActive(false);
    }
    IEnumerator FollowPath(){
        foreach (Tile waypoint in path)
        {
            Vector3 startPosition = transform.position;
            Vector3 waypointPosition = new Vector3(waypoint.transform.position.x,3,waypoint.transform.position.z);
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
