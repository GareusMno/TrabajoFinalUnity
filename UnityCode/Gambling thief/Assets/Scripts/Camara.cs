using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class Camara : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 orden = new Vector3 (0.0f,1.0f,0.0f);
        gameObject.GetComponent<Camera>().transparencySortAxis=orden;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
