
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    internal PlayerInput inputScript;
    [SerializeField]
    internal PlayerMovement movementScript;
    [SerializeField]
    internal PlayerCollision collisioScript;
    public static PlayerController Instance;
    internal Rigidbody2D rb;
    public float speed = 400f;
    public bool interactuar = false;
    internal Animator animator;
    internal string currentState;
    // Start is called before the first frame update
    private void Awake(){
        print("Main PlayerScript awakening");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Start(){
        if (Instance != null){
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        GameObject.DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    internal void ChangeState(string newState){
        if(newState!=currentState){
            animator.Play(newState);
            currentState = newState;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        interactuar=true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        interactuar=false;
    }
}
