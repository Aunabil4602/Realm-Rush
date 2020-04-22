
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NavigationMapper : MonoBehaviour
{
    private List<Waypoint> waypoints = null;
    private List<List<int>> adList = null;
    [SerializeField] private Waypoint startNode=null,endNode=null;

    // Specify movement of our agent. Hard Code because our Game rule if fixed
    // Allow only in X and Z directions
    private Vector3Int[] directions={
        new Vector3Int(1,0,0),     // Right
        new Vector3Int(-1,0,0),    // Left
        new Vector3Int(0,0,1),     // Forward
        new Vector3Int(0,0,-1)     // Backword
        // ,new Vector3Int(1,0,1)     // Upper Right
        // ,new Vector3Int(-1,0,1)    // Upper Left
        // ,new Vector3Int(-1,0,-1)   // Lowwer Left
        // ,new Vector3Int(-1,0,1)    // Lower Right
    };
    
    // Start is called before the first frame update
    void Start()
    {
        // Todo: Call from update() for runtime implementation;
        waypoints = GetComponentsInChildren<Waypoint>().OfType<Waypoint>().ToList();    //Get the whole list of block in the scene
        //AssignNN();
        GenerateMap();
        startNode.SetTopColor(Color.green);
        endNode.SetTopColor(Color.blue);

    }

    private void GenerateMap()
    {
        if(adList==null) adList = new List<List<int>>(); 
        string alist="";

        for(int i=0; i< waypoints.Count;i++)
        {
            adList.Add(new List<int>());
            waypoints[i].nodeNumber=i;

            foreach(Vector3 dir in directions)
            {
                int ni = IsNeighbor(NameMap(waypoints[i].GetPos() + dir));
                if( ni>0)
                {
                    adList[i].Add(ni);
                    alist += waypoints[i].gameObject.name + "--" + waypoints[ni].gameObject.name + "\n";
                }
            }
            //waypoints[i].SetTopColor(Color.yellow);
            
        }
        Debug.Log("Adjacency list: \n"+alist);
    }

    private int IsNeighbor(string name)
    {
        for(int i=0;i< waypoints.Count;i++)
            if(waypoints[i].gameObject.name==name) return i;

        return -1;
    }

    private string NameMap(Vector3 p)
    {
        return p.x + "," + p.z;
    }

    public int GetSNode()
    {
        if(startNode!=null)
        {
            if(startNode.nodeNumber<0)
            {
                Start();
            }
            return startNode.nodeNumber;
        }
        return -1;
    }

    public int GetENode()
    {
        if(endNode!=null)
        {
            if(endNode.nodeNumber<0)
            {
                Start();
            }
            return endNode.nodeNumber;
        }
        return -1;
    }

    public List<List<int>> GetWaypoints()
    {
        if(adList==null) Start();
        return adList;
    }

    public string GetName(int i)
    {
        if( i >=0 && i<waypoints.Count)
        {
            return waypoints[i].gameObject.name;
        }
        return "null";
    }

    public Waypoint GetNode(int i)
    {
        if(waypoints!=null) return waypoints[i];
        return null;
    }

}
