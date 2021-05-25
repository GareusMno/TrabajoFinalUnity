using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPuzzleNivel5 : MonoBehaviour
{
    public GameObject Piedra1,Piedra2,Base1,Base2;
    public GameObject LlaveSecreta,LlaveNivel;
    // Start is called before the first frame update
    // Update is called once per frame
    bool nvl = false, secret = false;
    void Update()
    {
        if(!nvl && Base1.GetComponent<PlacaDePresion>().tocado && Base2.GetComponent<PlacaDePresion>().tocado){
            LlaveNivel.SetActive(true);
            nvl = true;
        }
        if(!secret && Base1.GetComponent<Collider2D>().IsTouching(Piedra1.GetComponent<Collider2D>()) && Base2.GetComponent<Collider2D>().IsTouching(Piedra2.GetComponent<Collider2D>())){
            LlaveSecreta.SetActive(true);
            secret = true;
        }
    }
}
