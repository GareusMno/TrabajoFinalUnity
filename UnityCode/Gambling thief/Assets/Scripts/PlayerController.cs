
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public bool pausa;
    public GameObject pauseMenuUI;
    // Start is called before the first frame update
    private void Awake(){
        print("Main PlayerScript awakening");
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
    public void Pausar(){
        if(pausa){
            Volver();
        }else{
            Pause();
        }
    }
    public void Pause(){
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pausa = true;
    }
    public void Volver(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pausa = false;
    }
    public void SalirALaSeleccion(){
        Time.timeScale = 1f;
        pausa = false;
        SceneManager.LoadScene(1);
    }
    
}
