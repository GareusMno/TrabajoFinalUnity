using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFuegosNvl3 : MonoBehaviour
{
    public GameObject Fuego1,Fuego2,Fuego3,Fuego4,PuertaLlave,LlaveSecreto;
    int f1,f2,f3,f4;
    int num = 1;
    int[] FuegosPuzzleNivel = {2,4,1,3};
    int[] FuegosPuzzleSecreeto = {4,1,2,3};
    bool puzzle1 = false;
    bool puzzle2 = false;
    public void fuegoActivado(int nfuego){
        if(num==1){
            f1=nfuego;
            if(f1==1){
                Fuego1.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f1);
            }
            if(f1==2){
                Fuego2.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f1);
            }
            if(f1==3){
                Fuego3.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f1);
            }
            if(f1==4){
                Fuego4.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f1);
            }
        }
        if(num==2){
            f2=nfuego;
            if(f2==1){
                Fuego1.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f2);
            }
            if(f2==2){
                Fuego2.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f2);
            }
            if(f2==3){
                Fuego3.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f2);
            }
            if(f2==4){
                Fuego4.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f2);
            }
        }
        if(num==3){
            f3=nfuego;
            if(f3==1){
                Fuego1.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f3);
            }
            if(f3==2){
                Fuego2.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f3);
            }
            if(f3==3){
                Fuego3.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f3);
            }
            if(f3==4){
                Fuego4.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f3);
            }
        }
        if(num==4){
            f4=nfuego;
            if(f4==1){
                Fuego1.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f4);
            }
            if(f4==2){
                Fuego2.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f4);
            }
            if(f4==3){
                Fuego3.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f4);
            }
            if(f4==4){
                Fuego4.GetComponent<Animator>().SetBool("Accionado",true);
                Debug.Log(f4);
            }
            Debug.Log("Ultimo fuego");
            Debug.Log("Comprobando");
            PuzzleSecreto();
            PuzzleNivel();
            if(puzzle1 && puzzle2){
                Debug.Log("Fuegos completados");
            }else{
                Debug.Log("Fuegos incorrectos");
                Fuego1.GetComponent<Animator>().SetBool("Accionado",false);
                Fuego2.GetComponent<Animator>().SetBool("Accionado",false);
                Fuego3.GetComponent<Animator>().SetBool("Accionado",false);
                Fuego4.GetComponent<Animator>().SetBool("Accionado",false);
            }
            f1=0;
            f2=0;
            f3=0;
            f4=0;
            num=0;
            Debug.Log("Fuego 1:"+f1+"Fuego 2: "+f2+ "Fuego 3: "+f3+" Fuego 4:"+f4);
        }
        num++;
    }
    bool PuzzleSecreto(){
        if(f1==FuegosPuzzleSecreeto[0] && f2==FuegosPuzzleSecreeto[1] && f3==FuegosPuzzleSecreeto[2] && f4==FuegosPuzzleSecreeto[3]){
            puzzle2=true;
            LlaveSecreto.SetActive(true);
            return true;
        }
        return false;
    }
    bool PuzzleNivel(){
        if(f1==FuegosPuzzleNivel[0] && f2==FuegosPuzzleNivel[1] && f3==FuegosPuzzleNivel[2] && f4==FuegosPuzzleNivel[3]){
            puzzle1=true;
            PuertaLlave.SetActive(false);
            return true;
        }
        return false;
    }
}
