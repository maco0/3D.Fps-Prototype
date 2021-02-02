using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Movement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float fast = 20f;
    public float gravity = -9.81f;
    public float jump = 3f;
    public Transform groundChek;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;
    
    public ParticleSystem sprinter;
    void FixedUpdate()
    {
    
        isGrounded = Physics.CheckSphere(groundChek.position, groundDistance, groundMask);

        if(isGrounded&& velocity.y < 0)
        {
            velocity.y = -2f;
        }
         else if(velocity.y < -100f)
        {
            SceneManager.LoadScene(3);
        }

        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        
        Vector3 move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
           
            speed = fast;

            controller.Move(move * speed * Time.deltaTime);
             sprinter.Play(); 
        }
        else
        {
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
           speed= 12f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * (-2f) * gravity);
        }



        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }


}
