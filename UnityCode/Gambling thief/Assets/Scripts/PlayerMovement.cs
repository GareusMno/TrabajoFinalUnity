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
        } else{
            StopMovement();
        }
    }
    private void MovePlayer(){
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(mx,my).normalized;
        playerScript.rb.velocity = movement * playerScript.speed;
        playerScript.animator.SetFloat("Horizontal",mx);
        playerScript.animator.SetFloat("Vertical",my);
        playerScript.animator.SetBool("Caminar",true);
    }
    private void StopMovement(){
        playerScript.rb.velocity = new Vector2(0,0);
        playerScript.animator.SetBool("Caminar",false);
    }
}
