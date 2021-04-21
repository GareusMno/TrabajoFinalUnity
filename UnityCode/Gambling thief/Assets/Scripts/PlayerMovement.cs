using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    PlayerController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Player Movement Script Starting");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (playerScript.inputScript.isRightPressed || playerScript.inputScript.isLeftPressed || playerScript.inputScript.isUpPressed || playerScript.inputScript.isDownPressed){
            MovePlayer();
            playerScript.animator.SetBool("Caminar",true);
            if(playerScript.inputScript.isRightPressed || playerScript.inputScript.isLeftPressed){
                playerScript.animator.SetBool("Lados",true);
            }
            if(playerScript.inputScript.isUpPressed){
                playerScript.animator.SetBool("Arriba",true);
            }
            if(playerScript.inputScript.isDownPressed){
                playerScript.animator.SetBool("Abajo",true);
            }
        } else{
            StopMovement();
            playerScript.animator.SetBool("Caminar",false);
            playerScript.animator.SetBool("Abajo",false);
            playerScript.animator.SetBool("Arriba",false);
            playerScript.animator.SetBool("Lados",false);
        }
    }
    private void MovePlayer(){
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(mx,my).normalized;
        playerScript.rb.velocity = movement * playerScript.speed;
    }
    private void StopMovement(){
        playerScript.rb.velocity = new Vector2(0,0);
    }
}
