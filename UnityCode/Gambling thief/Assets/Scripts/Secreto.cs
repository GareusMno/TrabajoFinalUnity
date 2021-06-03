using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secreto : MonoBehaviour
{
    public AudioSource altavoz;
    public AudioClip sonido;
    public int levelIndex;
    void Start(){
        altavoz.clip = sonido;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        altavoz.Play();
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("Secret"+levelIndex,1);
        PlayerPrefs.SetInt("Lv"+levelIndex,1);

        Debug.Log("Secreto desbloqueado");
    }
}
