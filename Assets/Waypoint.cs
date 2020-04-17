using UnityEngine;


[DisallowMultipleComponent]
public class Waypoint : MonoBehaviour
{
    public int nodeNumber = -1;
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
        return (int)transform.position.x/(int)transform.localScale.x;
    }

    // Returns z position
    public int Getz()
    {
        return (int)transform.position.z/(int)transform.localScale.z;
    }
}
