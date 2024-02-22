using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajeController : MonoBehaviour
{
    public float speed = 0;
    public Animator animator;
    private Rigidbody rb;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        movementY = 1.0f;
        if(Input.GetKey(KeyCode.Space)) {
            animator.SetBool("isJumping", true);
        }
        else if(Input.GetKey(KeyCode.T)) {
            animator.SetBool("isWalking", true);

            Vector3 movement = new Vector3(0.0f, 0.0f, movementY);
            transform.Translate(movement * speed * Time.deltaTime);
            


        } else if(Input.GetKey(KeyCode.G)) {

            animator.SetBool("stopWalking", true);
        
        } else {
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("stopWalking", false);
        }

  
        
    }

}