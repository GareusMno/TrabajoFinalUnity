using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    public static bool menu = false;
    public GameObject pauseMenuUi;
    public GameObject cofreUI;
    private GameObject player;
    // Update is called once per frame
    void Start(){
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)){
            Debug.Log("Inventario");
            if (!menu){
                Abrir();
            }else{
                Cerrar();
            }
        }
        if (!gameObject.GetComponentInParent<PlayerController>().interactuar){
            CerrarCofre();
        }
    }
    void Abrir(){
        Debug.Log("Inventario Abierto");
        pauseMenuUi.SetActive(true);
        menu=true;
    }
    void Cerrar(){
        Debug.Log("Inventario Cerrado");
        pauseMenuUi.SetActive(false);
        menu=false;
    }
    public void AbrirCofre(){
        Debug.Log("Cofre abierto");
        Abrir();
        cofreUI.SetActive(true);
    }
    void CerrarCofre(){
        Debug.Log("Cofre cerrado");
        Cerrar();
        cofreUI.SetActive(false);
        
    }
}
