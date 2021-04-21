using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mesilla : MonoBehaviour
{
    public static bool menu = false;
    public GameObject pauseMenuUi;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)){
            if (!menu){
                Abrir();
            }else{
                Cerrar();
            }
        }
        if(Input.GetKeyDown(KeyCode.O)){
            Abrir();
        }
    }
    void Abrir(){
        Debug.Log("Cofre Abierto");
        pauseMenuUi.SetActive(true);
        menu=true;
    }
    void Cerrar(){
        Debug.Log("Cofre Cerrado");
        pauseMenuUi.SetActive(false);
        menu=false;
    }
}
