using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteInEditMode]
public class BFSTest : MonoBehaviour
{

    //private enum Colors { white, gray, black };

    List<List<int>> waypoints = null;        // A 2D adjacency list
    List<bool> visited = null;    // List of visited nodes
    List<int> parent = null, spath=null;
    int startNode = 0; //Starting node number
    int endNode = 0;

    [SerializeField] private NavigationMapper nm=null;
    

    // Start is called before the first frame update
    void Start()
    {
        //area = new List<List<int>>();
        //for (int i = 0; i < 10; i++)
        //{
        //    area.Add(new List<int>());
        //    for (int j = 0; j < 10; j++)
        //    {
        //        area[i].Add(j);
        //    }
        //}

        if(nm==null) nm =  GameObject.FindObjectOfType<NavigationMapper>();
        waypoints = nm.GetWaypoints();

        startNode = nm.GetSNode();
        endNode = nm.GetENode();

        print("Start node index: " + startNode + " End node index: " + endNode);

        FindShortestPath();
        GenerateSP();
        PrintShortestPath();

    }

    // Update is called once per frame
    void Update()
    {
        //if (area == null) Start();
        //string s="";
        //for (int i = 0; i < 10; i++)
        //{
        //    for (int j = 0; j < 10; j++)
        //    {
        //        s+= (i.ToString() + "," + area[i][j].ToString() + "\t");
        //    }
        //    s += "\n";
        //}
        //print(s);
        //print(area.Count);
        
    }

    private void FindShortestPath()
    {

        
        InitializeAll();    // First initialize all
        bool reached = false; // Check if we have reached out destination

        print("Size of visited: " + visited.Count);
        //visited[0] = true;

        // Check bound
        if (startNode >=0 && startNode < visited.Count) visited[startNode] = true;
        else
        {
            Debug.LogError("Start Node out of bound! " + startNode);
            Application.Quit();
            return;
        }
        if (endNode >= 0 && endNode < visited.Count) visited[startNode] = true;
        else
        {
            Debug.LogError("Start Node out of bound! " + endNode);
            Application.Quit();
            return;
        }
        
        if (startNode == endNode) reached = true;

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(startNode);

        string explore="";

        // Iterate through all nodes
        while(queue.Count>0)
        {
            
            if (reached == true) break; // If we've reached our destination then break
            int currentNode = queue.Dequeue();  // Dequeue the current node
            explore+= nm.GetName(currentNode) + "->";

            // Iterate through all adjacent nodes
            for( int i=0; i<waypoints[currentNode].Count; i++ )
            {   
                int adjacentNode = waypoints[currentNode][i];    //Get the adjacent Node

                // If adjacent node is not visited, then visit and add to queue
                if ( !visited[adjacentNode] )
                {
                    
                    visited[adjacentNode] = true;   // Visit the unvisited node
                    parent[adjacentNode] = currentNode; // Set parent of the adjacent nodes
                    queue.Enqueue(adjacentNode);    // Enqueue the newly visited node so that it can be expanded
                    
                    //If we've reached destination then break
                    if(adjacentNode == endNode)
                    {
                        reached = true;
                        break;
                    }
                    

                }
            }

        }
        print("Explore sequence: " + explore);
    }

    private void InitializeAll()
    {
        /**
        Initialize visited list and the predecessor list
        */
        if(visited!=null) visited.Clear(); // Clear visited
        if(parent!=null) parent.Clear();

        // Initialize list of visited nodes
        visited = new List<bool>();
        parent = new List<int>();

        for(int i=0; i< waypoints.Count; i++)
        {
            visited.Add(false);
            parent.Add(-1);
        }

    }

    private void PrintShortestPath()
    {
        if(spath==null) GenerateSP();
        string sp = "";

        foreach(int p in spath)
        {
            sp+= nm.GetName(p);
        }

        print(sp);
    }

    private void GenerateSP()
    {
        int cnode=endNode;
        spath = new List<int>();
        
        while(true)
        {
            spath.Add(cnode);
            cnode= parent[cnode];
            if(cnode==-1) break;
        }
        spath.Reverse();
    }

    public List<Waypoint> GetPath()
    {
        List<Waypoint> path = new List<Waypoint>();
        if(spath==null) Start();

        foreach(int i in spath)
        {
            path.Add( nm.GetNode(i) );
        }
        return path;

    }
}
