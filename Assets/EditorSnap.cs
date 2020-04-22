using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(Waypoint))]
public class EditorSnap : MonoBehaviour
{
    private const int gridSize = 10 ;
    [SerializeField] private TextMesh gridPosition = null;
    [SerializeField][Range(1f,20f)] private float uniformScaling = 10f;

    void Update()
    {
        Vector3 gridPos;
        gridPos.x = Mathf.RoundToInt(transform.position.x / gridSize ) *gridSize;
        gridPos.y = 0;
        gridPos.z = Mathf.RoundToInt(transform.position.z / gridSize ) *gridSize;
        transform.position = gridPos;

        string blockLabel = transform.position.x / gridSize + "," + transform.position.z / gridSize;

        gridPosition.text = blockLabel;

        transform.localScale = new Vector3(uniformScaling,uniformScaling,uniformScaling);
        gameObject.name = blockLabel;
    }

}
