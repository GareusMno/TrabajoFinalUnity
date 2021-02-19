using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    public bool isGrounded = false;
    public float Velocidad = 400f;
    public float Salto = 200f;
    // Start is called before the first frame update
    void Start(){
        if (Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("left")){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-Velocidad * Time.deltaTime,0));
            gameObject.GetComponent<SpriteRenderer>().flipX=true;
        }

        if(Input.GetKey("right")){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Velocidad * Time.deltaTime,0));
            gameObject.GetComponent<SpriteRenderer>().flipX=false;
        }
        
        if (!Input.GetKey("right")&&!Input.GetKey("left")){
        }

        if(Input.GetKeyDown("up") && isGrounded){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0,Salto));
            Debug.Log("Salto");
        }
    }
}
