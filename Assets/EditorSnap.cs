using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField][Range(1f,20f)] private float gridSize;

    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize ) *gridSize;
        snapPos.y = 0;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize ) *gridSize;
        transform.position = snapPos;

        //transform.localScale = new Vector3(gridSize,gridSize,gridSize);
    }

}
