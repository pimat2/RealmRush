using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] float secondsDelay = 2f;
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
            Vector3 waypointPosition = new Vector3(waypoint.transform.position.x,0,waypoint.transform.position.z);
            transform.position = waypointPosition;
            yield return new WaitForSeconds(secondsDelay);
        }
    }
}
