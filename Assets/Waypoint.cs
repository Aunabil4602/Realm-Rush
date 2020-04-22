using UnityEngine;


[DisallowMultipleComponent]
public class Waypoint : MonoBehaviour
{
    public int nodeNumber = -1;
    private const int gridSize = 10 ;
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Returns x position
    public int Getx()
    {
        return (int)transform.position.x/gridSize;
    }

    // Returns z position
    public int Getz()
    {
        return (int)transform.position.z/gridSize;
    }

    public Vector3Int GetPos()
    {
        return new Vector3Int((int)transform.position.x/gridSize,0,(int)transform.position.z/gridSize);
    }

    public void SetTopColor(Color c)
    {
        MeshRenderer topMeshRendered = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRendered.material.color = c;
    }
}
