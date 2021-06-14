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
        Debug.Log("Secreto desbloqueado");
        StartCoroutine(wait());
    }
    void Die(){
		
	}
    public IEnumerator wait(){
        gameObject.GetComponent<SpriteRenderer>().enabled=false;
        yield return new WaitForSeconds(2.0f);
        gameObject.SetActive(false);
        PlayerPrefs.SetInt("Secret"+levelIndex,1);
    }
}
