using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleNivelFuegoPuertas : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Fire1,Fire2,Fire3,Fire4,Fire5,Fire6,Fire7,Fire8;
    List<GameObject> Fuegos = new List<GameObject>();
    public GameObject PuertaIzquierda,PuertaDerecha,LlaveSecreto;
    bool activada = false;
    // Update is called once per frame
    void Start(){
        Fuegos.Add(Fire1);
        Fuegos.Add(Fire2);
        Fuegos.Add(Fire3);
        Fuegos.Add(Fire4);
        Fuegos.Add(Fire5);
        Fuegos.Add(Fire6);
        Fuegos.Add(Fire7);
        Fuegos.Add(Fire8);
    }
    public void fuegoActivado(GameObject fire){
        if(fire.GetComponent<Animator>().GetBool("Accionado")){
            fire.GetComponent<Animator>().SetBool("Accionado",false);
        }else{
            fire.GetComponent<Animator>().SetBool("Accionado",true);
        }
        puerta1();
    }
    void puerta1(){
        if(Fire2.GetComponent<Animator>().GetBool("Accionado") && !Fire1.GetComponent<Animator>().GetBool("Accionado")){
            PuertaIzquierda.SetActive(false);
        }
        if(Fire4.GetComponent<Animator>().GetBool("Accionado") && !Fire3.GetComponent<Animator>().GetBool("Accionado")){
            PuertaDerecha.SetActive(false);
        }
        if(!activada){
            if(Fire2.GetComponent<Animator>().GetBool("Accionado") && Fire4.GetComponent<Animator>().GetBool("Accionado") && Fire5.GetComponent<Animator>().GetBool("Accionado") && Fire7.GetComponent<Animator>().GetBool("Accionado") && Fire8.GetComponent<Animator>().GetBool("Accionado")){
                LlaveSecreto.SetActive(true);
                activada = true;
            }
        }
    }
}
