using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int length = 10;
    public int width = 10;
    public float cellSize = 2.5f;
    public float platformHeight = -1.0f;
    public GameObject platformCell;
    public GameObject gridParent;

    public void Build3DGrid(){
        ClearGrid();
        for (int y = 0; y < length; y++) 
        {
            for (int x = 0; x < width; x++)
            {
                Vector3 pos = new Vector3(x, platformHeight, y) * cellSize;
                CreatePlatformObject(pos);
            }
        }
    }
    private void ClearGrid(){
        foreach (Transform child in gridParent.transform) {
        GameObject.Destroy(child.gameObject);
 }
    }
    private void CreatePlatformObject(Vector3 position) {
        GameObject newObj;
        newObj = Instantiate(platformCell, position, Quaternion.identity);
        newObj.transform.parent = gridParent.transform;
    }

}
