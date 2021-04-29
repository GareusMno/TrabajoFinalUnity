using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoliceMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool walk = true;
    bool dir = true;
    public bool chase = false;
    bool invertir = false;
    public float speed;
    private float waitTime;
    public float startWaitTime;
    //SPOTS
    public Transform[] moveSpots;
    public int Spot = 0;
    
    [SerializeField]
    Transform player;
    private Animator animPolice;
    float agroRange = 1;
    Vector2 origin = new Vector2(-6,1);

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animPolice = GetComponent<Animator>();
        waitTime = startWaitTime;
    }

    // Update is called once per frame
    void Update()
    {  
        if(chase==false){
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
        }else{
            chasePlayer();
        }
        /*
        float distToPlayer = Vector2.Distance(transform.position,player.position);
        if (distToPlayer < agroRange){
            chasePlayer();
        }else{
            if (agroRange>10){
                chasePlayer();
            }else{
                StopMovement();
            }
        }
        */
    }
    private void MovePolice(){
        if(dir){
            rb.velocity = new Vector2(2,1)/2;
        }else{
            rb.velocity = new Vector2(-2,-1)/2;
        }
        
    }
    private void StopMovement(){
        rb.velocity = new Vector2(0,0);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        //Start the coroutine we define below named ExampleCoroutine.
        walk = false;
        dir = !dir;
        StartCoroutine(ExampleCoroutine());
    }
    IEnumerator ExampleCoroutine()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        walk = true;
    }
    private void chasePlayer(){
        transform.position = Vector3.MoveTowards(transform.position,player.position,1 * Time.deltaTime);
    }
    private void comeback(){
        transform.position = Vector2.MoveTowards(transform.position,origin,1 * Time.deltaTime);
        if (Vector2.Equals(transform.position,origin)){
            walk=true;
        }
    }
    /*
    bool CanSeePlayer(float distance){
        bool val = false;
        float castDist = distance;

        Vector2 endPos = castPoint.position + Vector3.right * distance;
        RaycastHit2D HIT = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Vision"));

        if (HIT.collider != null){
            if(HIT.collider.gameObject.CompareTag("Player")){
                val = true;
            }else{
                val = false;
            }
            Debug.DrawLine(castPoint.position,HIT.point,Color.red);
        }else{
            Debug.DrawLine(castPoint.position,endPos,Color.white);
        }
        return val;
    }
    */
}