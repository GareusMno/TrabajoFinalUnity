using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Llaves : MonoBehaviour
{
    public AudioSource altavoz;
    public AudioClip sonido;
    GameObject puertaNivel;
    GameObject puertaSecreto;
    GameObject llaveNivel;
    GameObject llaveSecreto;
    // Start is called before the first frame update
    void Start()
    {
        altavoz.clip = sonido;
        puertaNivel = GameObject.FindGameObjectWithTag("PuertaNivel");
        puertaSecreto = GameObject.FindGameObjectWithTag("PuertaSecreto");
        llaveNivel = GameObject.FindGameObjectWithTag("LlaveNivel");
        llaveSecreto = GameObject.FindGameObjectWithTag("LlaveSecreto");
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            if(this.CompareTag("LlaveNivel")){
                altavoz.Play();
                Debug.Log("Llave del nivel cogida");
                StartCoroutine(wait());
            }
            if(this.CompareTag("LlaveSecreto")){
                altavoz.Play();
                Debug.Log("Llave del secreo cogida");
                StartCoroutine(wait());
            }
        }
    }
    public IEnumerator wait(){
        gameObject.GetComponent<SpriteRenderer>().enabled=false;
        yield return new WaitForSeconds(2.0f);
        if(this.CompareTag("LlaveNivel")){
            llaveNivel.SetActive(false);
            puertaNivel.SetActive(false);
        }
        if(this.CompareTag("LlaveSecreto")){
            Debug.Log("Llave del secreo cogida");
            llaveSecreto.SetActive(false);
            puertaSecreto.SetActive(false);
        };
    }
}
