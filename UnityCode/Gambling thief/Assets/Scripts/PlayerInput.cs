using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    PlayerController playerScript;

    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isUpPressed;
    internal bool isDownPressed;
    internal bool isEscapePressed;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Input Script Starting");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)){
            isUpPressed = true;
        }else{
            isUpPressed = false;
        }
        if (Input.GetKey(KeyCode.A)){
            isLeftPressed = true;
        }else{
            isLeftPressed = false;
        }
        if (Input.GetKey(KeyCode.S)){
            isDownPressed = true;
        }else{
            isDownPressed = false;
        }
        if (Input.GetKey(KeyCode.D)){
            isRightPressed = true;
        }else{
            isRightPressed = false;
        }
        if(Input.GetKey(KeyCode.Escape)){
            playerScript.Pausar();
        }
    }
}
