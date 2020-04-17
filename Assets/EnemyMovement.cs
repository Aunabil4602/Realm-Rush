using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    
    [SerializeField] BFSTest spalgo=null;
    [SerializeField] List<Waypoint> path = null;

    // Start is called before the first frame update
    void Start()
    {
        print("Starting Patrol");
        path = spalgo.GetPath();
        StartCoroutine(FollowPath());

    }

    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            print("Visiting Block: " + waypoint.name);
            transform.position = waypoint.transform.position;

            yield return new WaitForSeconds(1.0f);
        }
        print("Ending Patrol");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void CalculateShortestPath()
    {

    }

}
