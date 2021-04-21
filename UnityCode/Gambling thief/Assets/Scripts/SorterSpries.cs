using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SorterSpries : MonoBehaviour
{
    // Start is called before the first frame update
    private const int IsometricRangePerYUnit = 256;
    public Grid worldGrid;
    private Renderer myRenderer;
    private Grid[] gridList;

    private void Awake() {
        myRenderer = gameObject.GetComponent<Renderer>();
        gridList = GameObject.FindObjectsOfType<Grid>();
        foreach (Grid g in gridList){
            if (g.tag == "worldGrid"){
                worldGrid=g;
            }
        }
    }
    void Update() {
        var gridRef = worldGrid.WorldToCell(transform.position);
        myRenderer.sortingOrder = -gridRef.y;
    }
}
