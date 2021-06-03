using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoClick : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource altavoz;
    public AudioClip sonido;
    public void Sonar(){
        altavoz.clip = sonido;
        altavoz.Play();
    }
}
