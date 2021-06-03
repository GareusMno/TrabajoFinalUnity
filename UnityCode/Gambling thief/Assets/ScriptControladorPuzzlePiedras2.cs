using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptControladorPuzzlePiedras2 : MonoBehaviour
{
    public GameObject Piedra1,Piedra2,Piedra3,Piedra4;
    public GameObject Base1,Base2,Base3,Base4;

    public GameObject LlaveSecreta,LlaveNivel;
    bool nvl = false;
    bool secret = false;

    void Update()
    {
        if(!nvl && Base1.GetComponent<PlacaDePresion>().tocado && Base2.GetComponent<PlacaDePresion>().tocado 
        && Base3.GetComponent<PlacaDePresion>().tocado && Base4.GetComponent<PlacaDePresion>().tocado){
            LlaveNivel.SetActive(true);
            nvl = true;
        }
        if(!secret && Base1.GetComponent<Collider2D>().IsTouching(Piedra1.GetComponent<Collider2D>()) 
        && Base2.GetComponent<Collider2D>().IsTouching(Piedra2.GetComponent<Collider2D>())
        && Base3.GetComponent<Collider2D>().IsTouching(Piedra3.GetComponent<Collider2D>())
        && Base4.GetComponent<Collider2D>().IsTouching(Piedra4.GetComponent<Collider2D>())){
            LlaveSecreta.SetActive(true);
            secret = true;
        }
    }
}
