using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool accion = true;
    public Animator animator;
    public void interactuar(){
        if (accion){
            Debug.Log("Abriendo puerta");
            animator.SetTrigger("AbrirPuerta");
            this.gameObject.GetComponent<BoxCollider2D>().enabled=false;
            accion = false;
        }else{
            Debug.Log("Cerrando puerta");
            animator.SetTrigger("CerrarPuerta");
            this.gameObject.GetComponent<BoxCollider2D>().enabled=true;
            accion = true;
        }
    }
}
