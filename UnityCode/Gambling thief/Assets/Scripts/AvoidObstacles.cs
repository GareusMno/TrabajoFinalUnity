using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidObstacles : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 3;
    // Start is called before the first frame update

    // Update is called once per frame
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position = transform.up * Time.deltaTime * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Walls")){
            this.transform.Rotate(transform.rotation.x,transform.rotation.y, transform.rotation.z - 90);
        }
    }
}
