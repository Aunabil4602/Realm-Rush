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
