using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llaves : MonoBehaviour
{
    GameObject puertaNivel;
    GameObject puertaSecreto;
    GameObject llaveNivel;
    GameObject llaveSecreto;
    // Start is called before the first frame update
    void Start()
    {
        puertaNivel = GameObject.FindGameObjectWithTag("PuertaNivel");
        puertaSecreto = GameObject.FindGameObjectWithTag("PuertaSecreto");
        llaveNivel = GameObject.FindGameObjectWithTag("LlaveNivel");
        llaveSecreto = GameObject.FindGameObjectWithTag("LlaveSecreto");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            if(this.CompareTag("LlaveNivel")){
                Debug.Log("Llave del nivel cogida");
                llaveNivel.SetActive(false);
                puertaNivel.SetActive(false);
            }
            if(this.CompareTag("LlaveSecreto")){
                Debug.Log("Llave del secreo cogida");
                llaveSecreto.SetActive(false);
                puertaSecreto.SetActive(false);
            }
        }
    }
}
