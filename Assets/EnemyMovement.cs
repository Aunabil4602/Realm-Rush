using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    [SerializeField] List<Block> path = null;

    // Start is called before the first frame update
    void Start()
    {
        foreach( Block p in path )
        {
            PrintAllWaypoint();
        }
    }

    private void PrintAllWaypoint()
    {
        foreach(Block waypoint in path)
        {
            print(waypoint.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
