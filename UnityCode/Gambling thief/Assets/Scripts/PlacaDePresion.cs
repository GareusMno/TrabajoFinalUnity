using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacaDePresion : MonoBehaviour
{
    public bool tocado = false;
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Piedra")){
            other.GetComponent<Transform>().position=gameObject.GetComponent<Transform>().position;
            other.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            tocado=true;
        }
    }
}
