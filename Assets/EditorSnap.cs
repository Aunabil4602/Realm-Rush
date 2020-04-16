using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[SelectionBase]
public class EditorSnap : MonoBehaviour
{
    [SerializeField][Range(1f,20f)] private float gridSize = 10f ;
    [SerializeField] private TextMesh gridPosition;
    [SerializeField][Range(1f,20f)] private float uniforScaling = 10f;

    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize ) *gridSize;
        snapPos.y = 0;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize ) *gridSize;
        transform.position = snapPos;
        
        gridPosition.text = transform.position.z/10 + "," + transform.position.x/10;

        transform.localScale = new Vector3(uniforScaling,uniforScaling,uniforScaling);
    }

}
