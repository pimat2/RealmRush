using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField][Range(0f, 5f)] float enemySpeed = 2f;
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start Here");
        StartCoroutine(PrintWaypointName());
        Debug.Log("Finishing Start");
    }
    IEnumerator PrintWaypointName(){
        foreach (Waypoint waypoint in path)
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
    }
}
