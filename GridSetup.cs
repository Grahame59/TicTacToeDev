using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GridSetup : MonoBehaviour
{

public Image cellPrefab;
public Image XImage;
public Image OImage;
public Transform gridParent;


    void Start()
{
    if (cellPrefab == null)
    {
        Debug.LogError("Cell Prefab is not assigned!");
        return;
    }

    if (gridParent == null)
    {
        Debug.LogError("Grid Parent is not assigned!");
        return;
    }

    Debug.Log("Starting grid setup...");

    // Instantiate cells in a 3x3 grid
    for (int row = 0; row < 3; row++)
    {
        for (int column = 0; column < 3; column++)
        {
            Image newCell = Instantiate(cellPrefab, gridParent);
            newCell.transform.localPosition = new Vector3(column, -row, 0);
            Debug.Log("Cell instantiated at: " + newCell.transform.position);
        }
    }

    Debug.Log("Grid setup complete.");
}

} 
