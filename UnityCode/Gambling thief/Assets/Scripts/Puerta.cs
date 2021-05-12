using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public bool accion = true;
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            Debug.Log("Abriendo puerta");
            animator.SetTrigger("AbrirPuerta");
            this.gameObject.GetComponent<BoxCollider2D>().enabled=false;
        }
    }
}
