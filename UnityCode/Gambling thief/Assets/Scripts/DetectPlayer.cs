using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    public bool chase = false;
    private Animator myAnim;
    private Transform player;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float range;
    public int Spot = 0;
    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        if (!chase){
            transform.position = Vector2.MoveTowards(transform.position, moveSpots[Spot].position, speed*Time.deltaTime);
            if (Vector2.Distance(transform.position, moveSpots[Spot].position)< 0.2f){
                if(waitTime <= 0){
                    if (Spot<3){
                        Spot += 1;
                        waitTime = startWaitTime;
                    }else{
                        Spot = 0;
                        waitTime = startWaitTime;
                    }
                    gameObject.GetComponentInChildren<fieldOfView>().Spot=Spot;
                    /*
                    if (!invertir){
                        Spot += 1;
                        waitTime = startWaitTime;
                        if (Spot == moveSpots.Length-1){
                            invertir = true;
                        }
                    }else{
                        Spot -= 1;
                        waitTime = startWaitTime;
                        if (Spot == 0){
                            invertir = false;
                        }
                    }
                    */
                }else{
                    waitTime -= Time.deltaTime;
                }
            }
            FollowPlayer();
        }
        if(Spot==0){
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        if(Spot==1){
            transform.rotation = Quaternion.Euler(0,0,270);
        }
        if(Spot==2){
            transform.rotation = Quaternion.Euler(0,0,180);
        }
        if(Spot==3){
            transform.rotation = Quaternion.Euler(0,0,90);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            chase = true;
        }else{
            chase = false;
        }
    }
    public void FollowPlayer(){
        myAnim.SetBool("isMoving",true);
        myAnim.SetFloat("moveX", (player.position.x - transform.position.x));
        myAnim.SetFloat("moveY",(player.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position,player.position,speed * Time.deltaTime);
    }
}
