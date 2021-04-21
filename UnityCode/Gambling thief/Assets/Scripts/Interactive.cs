using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactive : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    void Start(){

    }
    void Update(){
        if(isInRange){
            {
                if(Input.GetKeyDown(interactKey)){
                    interactAction.Invoke();
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        isInRange=true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        isInRange=false;
    }
}
