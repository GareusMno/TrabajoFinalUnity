using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireNvl7 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fire1,fire2,fire3,fire4,fire5,fire6,fire7,fire8,fire9,fire10,fire11,fire12,fire13,fire14,fire15;
    public GameObject puertaIzquierda,LlaveSecreto;
    // Update is called once per frame
    // Fire 1 Activa Fire 2 y Fire 6
    // Fire 2 Activa Fire 1, Fire 3 y Fire 7
    // Fire 3 Activa Fire 2, Fire 4 y Fire 8
    public void fuegoActivado(GameObject fire){
        if(!fire.GetComponent<Animator>().GetBool("Accionado")){
            fire.GetComponent<Animator>().SetBool("Accionado",true);
            if(fire==fire2){
                fuegoLados(fire1,fire3,fire7);
            }
            if(fire==fire3){
                fuegoLados(fire2,fire4,fire8);
            }
            if(fire==fire4){
                fuegoLados(fire3,fire5,fire9);
            }
            if(fire==fire6){
                fuegoLados(fire1,fire7,fire11);
            }
            if(fire==fire10){
                Debug.Log("Fuego 10 Activado");
                fuegoLados(fire5,fire9,fire15);
            }
            if(fire==fire12){
                fuegoLados(fire11,fire13,fire7);
            }
            if(fire==fire13){
                fuegoLados(fire12,fire14,fire8);
            }
            if(fire==fire14){
                fuegoLados(fire13,fire15,fire9);
            }
            if(fire==fire1){
                fuegoEsquina(fire2,fire6);
            }
            if(fire==fire5){
                fuegoEsquina(fire4,fire10);
            }
            if(fire==fire11){
                fuegoEsquina(fire6,fire12);
            }
            if(fire==fire15){
                fuegoEsquina(fire14,fire10);
            }
            if(fire==fire7){
                fuegoCentro(fire6,fire2,fire12,fire8);
            }
            if(fire==fire8){
                fuegoCentro(fire7,fire9,fire3,fire13);
            }
            if(fire==fire9){
                fuegoCentro(fire8,fire10,fire4,fire14);
            }
        }
        if(solucionNivel()){
            puertaIzquierda.SetActive(false);
            fire1.GetComponent<Animator>().SetBool("Accionado",false);
            fire5.GetComponent<Animator>().SetBool("Accionado",false);
            fire6.GetComponent<Animator>().SetBool("Accionado",false);
            fire8.GetComponent<Animator>().SetBool("Accionado",false);
            fire10.GetComponent<Animator>().SetBool("Accionado",false);
            fire11.GetComponent<Animator>().SetBool("Accionado",false);
            fire15.GetComponent<Animator>().SetBool("Accionado",false);
        }
        if(solucionSecreto()){
            LlaveSecreto.SetActive(true);
            fire2.GetComponent<Animator>().SetBool("Accionado",false);
            fire3.GetComponent<Animator>().SetBool("Accionado",false);
            fire4.GetComponent<Animator>().SetBool("Accionado",false);
            fire6.GetComponent<Animator>().SetBool("Accionado",false);
            fire8.GetComponent<Animator>().SetBool("Accionado",false);
            fire10.GetComponent<Animator>().SetBool("Accionado",false);
            fire12.GetComponent<Animator>().SetBool("Accionado",false);
            fire13.GetComponent<Animator>().SetBool("Accionado",false);
            fire14.GetComponent<Animator>().SetBool("Accionado",false);
        }
    }
    public void fuegoLados(GameObject firelado1, GameObject firelado2, GameObject firelado3){
        if(!firelado1.GetComponent<Animator>().GetBool("Accionado")){
            firelado1.GetComponent<Animator>().SetBool("Accionado",true);
        }else{
            firelado1.GetComponent<Animator>().SetBool("Accionado",false);
        }
        if(!firelado2.GetComponent<Animator>().GetBool("Accionado")){
            firelado2.GetComponent<Animator>().SetBool("Accionado",true);
        }else{
            firelado2.GetComponent<Animator>().SetBool("Accionado",false);
        }
        if(!firelado3.GetComponent<Animator>().GetBool("Accionado")){
            firelado3.GetComponent<Animator>().SetBool("Accionado",true);
        }else{
            firelado3.GetComponent<Animator>().SetBool("Accionado",false);
        }
    }
    public void fuegoEsquina(GameObject firelado1, GameObject firelado2){
        if(!firelado1.GetComponent<Animator>().GetBool("Accionado")){
            firelado1.GetComponent<Animator>().SetBool("Accionado",true);
        }else{
            firelado1.GetComponent<Animator>().SetBool("Accionado",false);
        }
        if(!firelado2.GetComponent<Animator>().GetBool("Accionado")){
            firelado2.GetComponent<Animator>().SetBool("Accionado",true);
        }else{
            firelado2.GetComponent<Animator>().SetBool("Accionado",false);
        }
    }
    public void fuegoCentro(GameObject firelado1, GameObject firelado2, GameObject firelado3,GameObject firelado4){
        if(!firelado1.GetComponent<Animator>().GetBool("Accionado")){
            firelado1.GetComponent<Animator>().SetBool("Accionado",true);
        }else{
            firelado1.GetComponent<Animator>().SetBool("Accionado",false);
        }
        if(!firelado2.GetComponent<Animator>().GetBool("Accionado")){
            firelado2.GetComponent<Animator>().SetBool("Accionado",true);
        }else{
            firelado2.GetComponent<Animator>().SetBool("Accionado",false);
        }
        if(!firelado3.GetComponent<Animator>().GetBool("Accionado")){
            firelado3.GetComponent<Animator>().SetBool("Accionado",true);
        }else{
            firelado3.GetComponent<Animator>().SetBool("Accionado",false);
        }
        if(!firelado4.GetComponent<Animator>().GetBool("Accionado")){
            firelado4.GetComponent<Animator>().SetBool("Accionado",true);
        }else{
            firelado4.GetComponent<Animator>().SetBool("Accionado",false);
        }
    }
    public bool solucionNivel(){
        if(fire1.GetComponent<Animator>().GetBool("Accionado") && !fire2.GetComponent<Animator>().GetBool("Accionado") && !fire3.GetComponent<Animator>().GetBool("Accionado")
        && !fire4.GetComponent<Animator>().GetBool("Accionado") && fire5.GetComponent<Animator>().GetBool("Accionado") && fire6.GetComponent<Animator>().GetBool("Accionado")
        && !fire7.GetComponent<Animator>().GetBool("Accionado") && fire8.GetComponent<Animator>().GetBool("Accionado") && !fire9.GetComponent<Animator>().GetBool("Accionado")
        && fire10.GetComponent<Animator>().GetBool("Accionado") && fire11.GetComponent<Animator>().GetBool("Accionado") && !fire12.GetComponent<Animator>().GetBool("Accionado")
        && !fire13.GetComponent<Animator>().GetBool("Accionado") && !fire14.GetComponent<Animator>().GetBool("Accionado") && fire15.GetComponent<Animator>().GetBool("Accionado")){
            return true;
        }else{
            return false;
        }
    }
    public bool solucionSecreto(){
        if(!fire1.GetComponent<Animator>().GetBool("Accionado") && fire2.GetComponent<Animator>().GetBool("Accionado") && fire3.GetComponent<Animator>().GetBool("Accionado")
        && fire4.GetComponent<Animator>().GetBool("Accionado") && !fire5.GetComponent<Animator>().GetBool("Accionado") && fire6.GetComponent<Animator>().GetBool("Accionado")
        && !fire7.GetComponent<Animator>().GetBool("Accionado") && fire8.GetComponent<Animator>().GetBool("Accionado") && !fire9.GetComponent<Animator>().GetBool("Accionado")
        && fire10.GetComponent<Animator>().GetBool("Accionado") && !fire11.GetComponent<Animator>().GetBool("Accionado") && fire12.GetComponent<Animator>().GetBool("Accionado")
        && fire13.GetComponent<Animator>().GetBool("Accionado") && fire14.GetComponent<Animator>().GetBool("Accionado") && !fire15.GetComponent<Animator>().GetBool("Accionado")){
            return true;
        }else{
            return false;
        }
    }
}
