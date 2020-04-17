using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NavigationMapper : MonoBehaviour
{
    private List<Waypoint> waypoints = null;
    private List<List<int>> adList = null;
    [SerializeField] private Waypoint startNode=null,endNode=null;
    
    // Start is called before the first frame update
    void Start()
    {
        // Todo: Call from update() for runtime implementation;
        waypoints = GetComponentsInChildren<Waypoint>().OfType<Waypoint>().ToList();    //Get the whole list of block in the scene
        //AssignNN();
        GenerateMap();
    }

    private void GenerateMap()
    {
        if(adList==null) adList = new List<List<int>>(); 
        string alist="";

        for(int i=0; i< waypoints.Count;i++)
        {
            adList.Add(new List<int>());
            waypoints[i].nodeNumber=i;
            
            // Find adjacent blocks in 4 directions
            for(int j=0;j<4;j++)
            {
                //print("Namemap="+NameMap(waypoints[i].Getx(), waypoints[i].Getz(), j));

                int ni = IsNeighbor( NameMap(waypoints[i].Getx(), waypoints[i].Getz(), j) );    // Get the neighbor index
                if(ni>0)
                {
                    adList[i].Add(ni);
                    alist+= waypoints[i].gameObject.name + "--" + waypoints[ni].gameObject.name+"\n";
                }
            }
        }
        Debug.Log("Adjacency list: \n"+alist);
    }

    private int IsNeighbor(string name)
    {
        for(int i=0;i< waypoints.Count;i++)
            if(waypoints[i].gameObject.name==name) return i;

        return -1;
    }

    private string NameMap(int i,int j,int k)
    {
        if(k ==0 ) return i.ToString() + "," + (j-1).ToString(); 
        if(k ==1 ) return i.ToString() + "," + (j+1).ToString(); 
        if(k ==2 ) return (i-1).ToString() + "," + j.ToString(); 
        return (i+1).ToString() + "," + j.ToString(); 
    }

    // private void AssignNN()
    // {
    //     for(int i=0;i<waypoints.Count;i++)
    //     {
            
    //     }
    // }

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
