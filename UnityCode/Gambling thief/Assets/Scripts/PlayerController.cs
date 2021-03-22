
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody2D rb;
    public bool isGrounded = false;
    public float speed = 400f;
    public float Salto = 200f;
    public float Escalar = 50f;
    public float distance;
    public bool Climbing;
    public LayerMask whatIsLadder;
    public bool interactuar = false;
    public Animator animator;
    GameObject objetoInteractuable;
    // Start is called before the first frame update
    void Start(){
        if (Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
        
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(inputHorizontal * speed, rb.velocity.y);
        
        if (!Input.GetKeyDown("right")&&!Input.GetKeyDown("left")){
            gameObject.GetComponent<Animator>().SetBool("Walk",false);
        }
        if (Input.GetKeyDown("right")){
            Debug.Log("Derecha");
            gameObject.GetComponent<SpriteRenderer>().flipX=false;
            gameObject.GetComponent<Animator>().SetBool("Walk",true);
        }
        if (Input.GetKeyDown("left")){
            Debug.Log("Izquierda");
            gameObject.GetComponent<SpriteRenderer>().flipX=true;
            gameObject.GetComponent<Animator>().SetBool("Walk",true);
        }

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,Salto));
            Debug.Log("Salto");
        }

        if(Input.GetKeyDown(KeyCode.X) && objetoInteractuable!=null){
            Debug.Log(objetoInteractuable);
            objetoInteractuable.GetComponent<Puerta>().interactuar();
        }
        if(Input.GetKeyDown(KeyCode.Z)){
            objetoInteractuable = GameObject.FindGameObjectWithTag("Puerta");
            objetoInteractuable.GetComponent<Puerta>().interactuar();
        }
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.up,distance,whatIsLadder);
        if(hitInfo.collider != null){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
                Climbing = true;
            }
        }else{
            Climbing= false;
        }
        if (Climbing){
            inputVertical = Input.GetAxisRaw("Vertical");
            animator.SetBool("Climb",true);
            rb.velocity = new Vector2(inputHorizontal * speed,inputVertical * speed);
            rb.gravityScale = 0;
        }else{
            Debug.Log("Paro de escalar");
            animator.SetBool("Climb",false);
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag=="Puerta"){
            Debug.Log("Puerta");
            objetoInteractuable = GameObject.FindGameObjectWithTag("Puerta");
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        objetoInteractuable = null;
    }
}
