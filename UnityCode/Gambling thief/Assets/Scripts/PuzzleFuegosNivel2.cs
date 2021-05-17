using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFuegosNivel2 : MonoBehaviour
{
    public GameObject Fuego1,Fuego2,Fuego3,Fuego4,PuertaLlave,LlaveSecreto;
    int f1,f2,f3,f4;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void fuegoActivado(int nfuego){
        if(nfuego==1){
            f1=nfuego;
            Fuego1.GetComponent<Animator>().SetBool("Accionado",true);
            Debug.Log(f1);
        }
        if(nfuego==2){
            f2=nfuego;
            Fuego2.GetComponent<Animator>().SetBool("Accionado",true);
            Debug.Log(f2);
        }
        if(nfuego==3){
            f3=nfuego;
            Fuego3.GetComponent<Animator>().SetBool("Accionado",true);
            Debug.Log(f3);
        }
        if(nfuego==4){
            f4=nfuego;
            Fuego4.GetComponent<Animator>().SetBool("Accionado",true);
            Debug.Log(f4);
        }
        PuzzleSecreto();
        PuzzleNivel();
    }
    bool PuzzleSecreto(){
        if(f3!=0 && f4!=0){
            LlaveSecreto.SetActive(true);
            return true;
        }
        return false;
    }
    bool PuzzleNivel(){
        if(f1!=0 && f2!=0){
            PuertaLlave.SetActive(false);
            return true;
        }
        return false;
    }
}
