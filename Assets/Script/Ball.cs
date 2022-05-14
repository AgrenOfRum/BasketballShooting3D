using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public float jumpForce;
    
    
    private void OnCollisionEnter(Collision collision)


    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Dribble();

            
            
        }

    }

    void Dribble()
    {
        rb.velocity = Vector3.up * jumpForce;
        rb.AddTorque(transform.right * 1);
        rb.AddTorque(transform.up * 2);

    }







}
