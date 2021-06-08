using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPuzzle9 : MonoBehaviour
{
    public GameObject Piedra1,Piedra2,Piedra3;
    public GameObject Base1,Base2,Base3;
    public GameObject LlaveSecreta,LlaveNivel;
    bool nvl = false;
    void Update()
    {
        if(!nvl && Base1.GetComponent<PlacaDePresion>().tocado && Base2.GetComponent<PlacaDePresion>().tocado && Base3.GetComponent<PlacaDePresion>().tocado){
            LlaveNivel.SetActive(true);
            LlaveSecreta.SetActive(true);
            nvl = true;
        }
    }
}
