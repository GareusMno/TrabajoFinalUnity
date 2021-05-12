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
            if(playerScript.inputScript.isLeftPressed){
                gameObject.GetComponentInChildren<SpriteRenderer>().flipX=true;
            }else{
                gameObject.GetComponentInChildren<SpriteRenderer>().flipX=false;
            }
            MovePlayer();
        } else{
            StopMovement();
        }
    }
    private void MovePlayer(){
        float mx = Input.GetAxisRaw("Horizontal");
        float my = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(mx,my).normalized;
        playerScript.rb.velocity = movement * playerScript.speed * Time.deltaTime;
        playerScript.animator.SetFloat("mx",mx);
        playerScript.animator.SetFloat("my",my);
        playerScript.animator.SetBool("Movement",true);
    }
    private void StopMovement(){
        gameObject.GetComponentInChildren<SpriteRenderer>().flipX=false;
        playerScript.rb.velocity = new Vector2(0,0);
        playerScript.animator.SetBool("Movement",false);
    }
}
